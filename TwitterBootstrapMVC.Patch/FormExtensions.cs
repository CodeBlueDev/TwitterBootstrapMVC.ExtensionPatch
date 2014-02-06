using TwitterBootstrap3;

namespace TwitterBootstrapMVC.Patch
{
    public static class FormExtensions
    {
        public static Form InputWidthLg(this Form form, int inputWidth)
        {
            form._inputWidthLg = inputWidth;
            return form;
        }

        public static Form InputWidthMd(this Form form, int inputWidth)
        {
            form._inputWidthMd = inputWidth;
            return form;
        }

        public static Form InputWidthSm(this Form form, int inputWidth)
        {
            form._inputWidthSm = inputWidth;
            return form;
        }

        public static Form InputWidthXs(this Form form, int inputWidth)
        {
            form._inputWidthXs = inputWidth;
            return form;
        }

        public static Form LabelWidthLg(this Form form, int labelWidth)
        {
            form._labelWidthLg = labelWidth;
            form._formType = FormType.Horizontal;
            return form;
        }

        public static Form LabelWidthMd(this Form form, int labelWidth)
        {
            form._labelWidthMd = labelWidth;
            form._formType = FormType.Horizontal;
            return form;
        }

        public static Form LabelWidthSm(this Form form, int labelWidth)
        {
            form._labelWidthSm = labelWidth;
            form._formType = FormType.Horizontal;
            return form;
        }

        public static Form LabelWidthXs(this Form form, int labelWidth)
        {
            form._labelWidthXs = labelWidth;
            form._formType = FormType.Horizontal;
            return form;
        }

        public static Form Type(this Form form, FormType type)
        {
            form._formType = type;
            return form;
        }
    }
}
