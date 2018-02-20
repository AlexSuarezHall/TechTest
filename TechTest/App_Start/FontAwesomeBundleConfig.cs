using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(TechTest.App_Start.FontAwesomeBundleConfig), "RegisterBundles")]

namespace TechTest.App_Start
{
	public class FontAwesomeBundleConfig
	{
		public static void RegisterBundles()
		{
			BundleTable.Bundles.Add(new StyleBundle("~/Content/fontawesome").Include("~/Content/fontawesome/font-awesome.css"));
		}
	}
}