using System.Text.RegularExpressions;

namespace MyFirstApp.CustomConstraints
{
    // Eg: sales-report/2020/apr


    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // Check wether the value exists
            if (!values.ContainsKey(routeKey)) // key is month
            {
                return false; // not a match
            }

            Regex regex = new Regex("^(apr|jul|oct|jan)$");

            string? monthValue = Convert.ToString(values[routeKey]);

            if (regex.IsMatch(monthValue))
            {
                return true; // I is a match
            }
           
            
            return false;
        }
    }
}
