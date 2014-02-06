using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using TwitterBootstrapMVC.Infrastructure.Enums;

namespace TwitterBootstrapMVC.Patch
{
    public class Form : TwitterBootstrapMVC.Form
    {
        public string _action { get; set; }
        public ActionTypePassed _actionTypePassed { get;  set; }
        public AjaxOptions _ajaxOptions { get; set; }
        public string _controller { get;  set; }
        public FormMethod _formMethod { get;  set; }
        public dynamic _formType { get;  set; }
        public int? _inputWidthLg { get;  set; }
        public int? _inputWidthMd { get;  set; }
        public int? _inputWidthSm { get;  set; }
        public int? _inputWidthXs { get;  set; }
        public int? _labelWidthLg { get;  set; }
        public int? _labelWidthMd { get;  set; }
        public int? _labelWidthSm { get;  set; }
        public int? _labelWidthXs { get;  set; }
        public ActionResult _result { get;  set; }
        public RouteValueDictionary _routeValues { get;  set; }
        public Task<ActionResult> _taskResult { get;  set; }

        private IDictionary<string, object> _htmlAttributes; 

        public IDictionary<string, object> htmlAttributes {
            get { return _htmlAttributes; }
            set
            {
                HtmlAttributes(value);
            } 
        }

        public Form() : base()
        {
            _routeValues = new RouteValueDictionary();
            _formMethod = System.Web.Mvc.FormMethod.Post;
            _actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public Form(string action) : base(action)
        {
            _routeValues = new RouteValueDictionary();
            _action = action;
            _formMethod = System.Web.Mvc.FormMethod.Post;
            _actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public Form(Task<ActionResult> taskResult) : base(taskResult)
        {
            _routeValues = new RouteValueDictionary();
            _taskResult = taskResult;
            _formMethod = System.Web.Mvc.FormMethod.Post;
            _actionTypePassed = ActionTypePassed.HtmlTaskResult;
        }

        public Form(ActionResult result) : base(result)
        {
            _routeValues = new RouteValueDictionary();
            _result = result;
            _formMethod = System.Web.Mvc.FormMethod.Post;
            _actionTypePassed = ActionTypePassed.HtmlActionResult;
        }

        public Form(string action, string controller) : base(action, controller)
        {
            _routeValues = new RouteValueDictionary();
            _action = action;
            _controller = controller;
            _formMethod = System.Web.Mvc.FormMethod.Post;
            _actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public new Form AjaxOptions(AjaxOptions ajaxOptions)
        {
            _ajaxOptions = ajaxOptions;
            base.AjaxOptions(ajaxOptions);
            return this;
        }

        public new Form Class(string cssClass)
        {
            htmlAttributes.AddOrMergeCssClass("class", cssClass);
            base.Class(cssClass);
            return this;
        }

        public new Form Data(object htmlDataAttributes)
        {
            htmlAttributes.MergeHtmlAttributes(htmlDataAttributes.ToHtmlDataAttributes());
            base.Data(htmlDataAttributes);
            return this;
        }

        public new Form FormMethod(FormMethod formMethod)
        {
            _formMethod = formMethod;
            base.FormMethod(formMethod);
            return this;
        }

        public new Form HtmlAttributes(object htmlAttributes)
        {
            this.htmlAttributes.MergeHtmlAttributes(htmlAttributes.ToDictionary());
            base.HtmlAttributes(htmlAttributes);
            return this;
        }

        public new Form HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this.htmlAttributes.MergeHtmlAttributes(htmlAttributes);
            base.HtmlAttributes(htmlAttributes);
            return this;
        }

        public new Form Id(string id)
        {
            htmlAttributes.AddOrReplaceAttribute("id", id);
            base.Id(id);
            return this;
        }

        public new Form RouteValues(object routeValues)
        {
            _routeValues.MergeHtmlAttributes(routeValues.ToDictionary());
            base.RouteValues(routeValues);
            return this;
        }

        public new Form RouteValues(RouteValueDictionary routeValues)
        {
            _routeValues.MergeHtmlAttributes(routeValues);
            base.RouteValues(routeValues);
            return this;
        }
    }
}
