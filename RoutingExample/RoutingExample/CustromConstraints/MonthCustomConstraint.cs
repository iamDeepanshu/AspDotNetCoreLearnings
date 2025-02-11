
using System.Text.RegularExpressions;

namespace RoutingExample.CustromConstraints
{
    // first we have to implement IRouteConstraint interface, using quick implements
    public class MonthCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {   //Check if the parameter value exists
            if (!values.ContainsKey(routeKey)) //month
            { 
                   return false; // not a match
            }
            //creating constraint
            Regex regex = new Regex("^(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)");

            string? monthValue = Convert.ToString(values[routeKey]);

            if (regex.IsMatch(monthValue)) 
            {
                return true; // it is a match
            }

            return false;
        }
    }
}
