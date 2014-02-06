using TwitterBootstrapMVC.BootstrapMethods;

namespace TwitterBootstrapMVC.Patch
{
    public static class FormBuilderExtensions
    {
        public static BootstrapControlGroupBase<TModel> FormGroup<TModel>(this FormBuilder<TModel> builder)
        {
            var htmlHelper = builder.GetHtmlHelper();
            if (htmlHelper != null)
            {
                return new BootstrapControlGroupBase<TModel>(htmlHelper, builder.GetFormType(), builder.GetLabelXs(), builder.GetLabelSm(), builder.GetLabelMd(), builder.GetLabelLg(), builder.GetInputXs(), builder.GetInputSm(), builder.GetInputMd(), builder.GetInputLg());
            }
            return new BootstrapControlGroupBase<TModel>(builder.GetAjaxHelper(), builder.GetFormType(), builder.GetLabelXs(), builder.GetLabelSm(), builder.GetLabelMd(), builder.GetLabelLg(), builder.GetInputXs(), builder.GetInputSm(), builder.GetInputMd(), builder.GetInputLg());
        }
    }
}
