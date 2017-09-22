using System.Web.Mvc;

namespace SimpleApp.Areas.CustomStuff
{
    public class CustomStuffAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CustomStuff";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CustomStuff_default",
                "CustomStuff/{controller}/{action}",
                new { action = "Index" }
            );
        }
    }
}