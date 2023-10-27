using System.Linq.Expressions;

namespace DemoCrudAdoNet.Repositories.Users;

public class SqlExpressionVisitor<T>
{
    public SqlExpressionVisitor()
    {
        
    }

    public string Translate(Expression<Func<T, bool>> expression)
    {
        // Implement the translation logic for the expression to SQL query here
        // You can use ExpressionVisitor or any other method to traverse the expression tree and generate the SQL query

        // Example translation logic:
        if (expression.Body is BinaryExpression binaryExpression)
        {
            string left = Visit(binaryExpression.Left);
            string right = Visit(binaryExpression.Right);
            string op = GetOperator(binaryExpression.NodeType);

            return $"({left} {op} {right})";
        }

        throw new NotSupportedException("Expression type not supported");
    }

    private string Visit(Expression expression)
    {
        if (expression is MemberExpression memberExpression)
        {
            return memberExpression.Member.Name;
        }
        else if (expression is ConstantExpression constantExpression)
        {
            return FormatValue(constantExpression.Value);
        }

        throw new NotSupportedException("Expression type not supported");
    }

    private string GetOperator(ExpressionType nodeType)
    {
        switch (nodeType)
        {
            case ExpressionType.Equal:
                return "=";
            case ExpressionType.NotEqual:
                return "<>";
            case ExpressionType.GreaterThan:
                return ">";
            case ExpressionType.GreaterThanOrEqual:
                return ">=";
            case ExpressionType.LessThan:
                return "<";
            case ExpressionType.LessThanOrEqual:
                return "<=";
            default:
                throw new NotSupportedException("Operator not supported");
        }
    }

    private string FormatValue(object value)
    {
        if (value is string strValue)
        {
            return $"'{strValue}'";
        }
        else if (value is bool boolValue)
        {
            return boolValue ? "1" : "0";
        }
        else if (value is DateTime dateTimeValue)
        {
            return $"'{dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss")}'";
        }

        return value.ToString();
    }
}