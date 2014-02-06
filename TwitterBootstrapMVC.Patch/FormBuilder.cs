using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.Infrastructure.Enums;

namespace TwitterBootstrapMVC.Patch
{
    public class FormBuilder<TModel> : BuilderBase<TModel, Form>
    {
        private readonly bool _isDisposable;

        public FormBuilder(AjaxHelper<TModel> ajaxHelper, Form form, bool isDispoable = false) : base(ajaxHelper, form)
        {
            _isDisposable = isDispoable;
            ajaxHelper.ViewContext.HttpContext.Items["bmvc_view_data_form"] = element;
            if (element._formType != null)
            {
                element.htmlAttributes.AddOrMergeCssClass("class", BootstrapHelper.GetClassForFormType((string)(element._formType).ToString()));
            }
            if (!_isDisposable)
            {
                return;
            }
            switch (element._actionTypePassed)
            {
                case ActionTypePassed.HtmlRegular:
                    if (element._routeValues.Count == 0)
                    {
                        element._routeValues = HttpContext.Current.Request.QueryString.ToRouteValues();
                    }
                    ajaxHelper.BeginForm(element._action, element._controller, element._routeValues, element._ajaxOptions, element.htmlAttributes);
                    break;
                case ActionTypePassed.HtmlActionResult:
                    ajaxHelper.BeginForm(element._result, element._ajaxOptions, element.htmlAttributes);
                    break;
                case ActionTypePassed.HtmlTaskResult:
                    ajaxHelper.BeginForm(element._taskResult, element._ajaxOptions, element.htmlAttributes);
                    break;
                default:
                    ajaxHelper.ViewContext.HttpContext.AddError(new Exception(string.Format("Unexpected Ajax Form ActionType of {0}.", element._actionTypePassed)));
                    break;
            }
        }

        public FormBuilder(HtmlHelper<TModel> htmlHelper, Form form, bool isDisposable = false) : base(htmlHelper, form, isDisposable)
        {
            _isDisposable = isDisposable;
            htmlHelper.ViewContext.HttpContext.Items["bmvc_view_data_form"] = element;
            if (element._formType != null)
            {
                element.htmlAttributes.AddOrMergeCssClass("class", BootstrapHelper.GetClassForFormType((string)(element._formType).ToString()));
            }
            if (!_isDisposable)
            {
                return;
            }
            switch (element._actionTypePassed)
            {
                case ActionTypePassed.HtmlRegular:
                    if (element._routeValues.Count == 0)
                    {
                        element._routeValues = HttpContext.Current.Request.QueryString.ToRouteValues();
                    }
                    htmlHelper.BeginForm(element._action, element._controller, element._routeValues, element._formMethod, element.htmlAttributes);
                    break;
                case ActionTypePassed.HtmlActionResult:
                    htmlHelper.BeginForm(element._result, element._formMethod, element.htmlAttributes);
                    break;
                case ActionTypePassed.HtmlTaskResult:
                    htmlHelper.BeginForm(element._taskResult, element._formMethod, element.htmlAttributes);
                    break;
                default:
                    htmlHelper.ViewContext.HttpContext.AddError(new Exception(string.Format("Unexpected Html Form ActionType of {0}.", element._actionTypePassed)));
                    break;
            }
        }

        public override void Dispose()
        {
            if (_isDisposable)
            {
                textWriter.Write("</form>");
            }
            if (htmlHelper != null)
            {
                htmlHelper.ViewContext.HttpContext.Items["bmvc_view_data_form"] = null;
            }
            if (ajaxHelper != null)
            {
                ajaxHelper.ViewContext.HttpContext.Items["bmvc_view_data_form"] = null;
            }
            base.Dispose();
        }

        public AjaxHelper<TModel> GetAjaxHelper()
        {
            return ajaxHelper;
        }

        public HtmlHelper<TModel> GetHtmlHelper()
        {
            return htmlHelper;
        }

        public dynamic GetFormType()
        {
            return element._formType;
        }

        public int? GetInputLg()
        {
            return element._inputWidthLg;
        }

        public int? GetInputMd()
        {
            return element._inputWidthMd;
        }

        public int? GetInputSm()
        {
            return element._inputWidthSm;
        }

        public int? GetInputXs()
        {
            return element._inputWidthXs;
        }

        public int? GetLabelLg()
        {
            return element._labelWidthLg;
        }

        public int? GetLabelMd()
        {
            return element._labelWidthMd;
        }

        public int? GetLabelSm()
        {
            return element._labelWidthSm;
        }

        public int? GetLabelXs()
        {
            return element._labelWidthXs;
        }
    }
}
