using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using System;

namespace Web_Project {
    public static class Extentions {
        public static IHtmlContent LabelwithStyleFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) {
            return htmlHelper.LabelFor(expression, new { @class = "class='chk_label'" });
        }
    }
}
