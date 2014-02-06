using System.Web.Mvc;

namespace TwitterBootstrapMVC.Patch
{
    public static class BootstrapHtmlExtension
    {
        public static Bootstrap<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new Bootstrap<TModel>(htmlHelper);
        }

        public static BootstrapAjax<TModel> BootstrapAjax<TModel>(this AjaxHelper<TModel> ajaxHelper)
        {
            return new BootstrapAjax<TModel>(ajaxHelper);
        }
    }
}
