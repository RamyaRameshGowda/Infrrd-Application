using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Infrrd_Application.Controllers
{
    public static class Helper
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(this IList<ListBoxItem> items, String optionLabel = null, String optionValue = null, String selectedValue = null)
        {
            var list = new List<SelectListItem>();
            if (!String.IsNullOrEmpty(optionLabel))
            {
                list.Add(new SelectListItem { Text = optionLabel, Value = (String.IsNullOrEmpty(optionValue) ? "" : optionValue) });
            }
            foreach (var item in items)
            {
                var selectListItem = new SelectListItem
                {
                    Value = item.Value,
                    Text = item.Text,
                    Selected = item.Selected
                };
                selectListItem.Selected = selectListItem.Value == selectedValue;
                list.Add(selectListItem);
            }
            return list;
        }
    }

    [DataContract]
    public class ListBoxItem
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DataMember]
        public String Value { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [DataMember]
        public String Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ListBoxItem"/> is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public Boolean Selected { get; set; }

        [DataMember]
        public string EmailId { get; set; }
    }
}
