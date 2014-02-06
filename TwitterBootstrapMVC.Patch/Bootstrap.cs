using System.Web.Mvc;
using TwitterBootstrapMVC.BootstrapMethods;
using TwitterBootstrapMVC.Controls.V3;
using TwitterBootstrapMVC.Infrastructure.ConfigurationClasses;

namespace TwitterBootstrapMVC.Patch
{

    public class Bootstrap<TModel> : BootstrapBase<TModel>
    {
        public Bootstrap(HtmlHelper<TModel> htmlHelper) : base(htmlHelper)
        {
            VersionSpecific.Version = 3;
        }

        public FormBuilder<TModel> Begin(Form form)
        {
            return new FormBuilder<TModel>(Html, form, true);
        }

        public BootstrapColClass ColClass()
        {
            return new BootstrapColClass();
        }

        public BootstrapControlGroupBase<TModel> FormGroup()
        {
            return new BootstrapControlGroupBase<TModel>(Html);
        }
    }
}
