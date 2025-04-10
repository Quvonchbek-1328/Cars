















using System.Collections.Generic;
using System.Web.Mvc;

namespace Entity.Models.StaticModels
{
	public static class SelectYearListItem
	{
        
        public static List<SelectListItem> SelectListItems()
        {
            List <SelectListItem> result = new List<SelectListItem>();
            int Year=DateTime.Now.Year;
            for (int year = Year-4; year <= Year; year++)
            {
                result.Add(new SelectListItem {Text = year.ToString(),Value=year.ToString()});
            }
            return result;
        }
    }
}
