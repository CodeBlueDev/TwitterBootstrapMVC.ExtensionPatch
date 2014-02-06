using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TwitterBootstrap3;
using TwitterBootstrapMVC.BootstrapMethods;
using TwitterBootstrapMVC.Infrastructure.ConfigurationClasses;

namespace TwitterBootstrapMVC.Patch
{
    public class BootstrapAjax<TModel> : BootstrapBaseAjax<TModel, FormType>
    {
        public BootstrapAjax(AjaxHelper<TModel> ajaxHelper) : base(ajaxHelper)
        {
            VersionSpecific.Version = 3;
        }

        public FormBuilder<TModel> Begin(Form form, AjaxOptions ajaxOptions)
        {
            form._ajaxOptions = ajaxOptions;
            return new FormBuilder<TModel>(Ajax, form);
        }
    }
}
