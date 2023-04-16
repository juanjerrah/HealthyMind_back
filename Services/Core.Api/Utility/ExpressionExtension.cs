using System.Linq.Expressions;

namespace Core.Api.Utility;

public static class ExpressionExtension
{
    /// <summary>
    /// Begin an expression chain
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">Default return value if the chanin is ended early</param>
    /// <returns>A lambda expression stub</returns>
    public static Expression<Func<T, bool>> Begin<T>(bool value = false)
        => value ? parameter => true : parameter => false;

    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right) =>
        CombineLambdas(left, right, ExpressionType.AndAlso);

    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right) => CombineLambdas(left, right, ExpressionType.OrElse);

    #region private

    private static Expression<Func<T, bool>> CombineLambdas<T>(this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right, ExpressionType expressionType)
    {
        //Remove expressions created with Begin<T>()
        if (IsExpressionBodyConstant(left))
            return (right);

        var p = left.Parameters[0];

        var visitor = new SubstituteParameterVisitor
        {
            Sub =
            {
                [right.Parameters[0]] = p
            }
        };

        var body = Expression.MakeBinary(expressionType, left.Body, visitor.Visit(right.Body));
        return Expression.Lambda<Func<T, bool>>(body, p);
    }

    private static bool IsExpressionBodyConstant<T>(Expression<Func<T, bool>> left)
        => left.Body.NodeType == ExpressionType.Constant;

    private class SubstituteParameterVisitor : ExpressionVisitor
    {
        public readonly Dictionary<Expression, Expression> Sub = new();

        protected override Expression VisitParameter(ParameterExpression node)
            => Sub.TryGetValue(node, out var newValue) ? newValue : node;
    }

    #endregion
}