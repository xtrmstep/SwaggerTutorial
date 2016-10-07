using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.ModelBinding;
using Xunit;

namespace BookStoreApiService.Controllers.Helpers.Tests
{
    public class ControllerHelpersTests
    {
        [Fact]
        public void Should_convert_model_state_errors_to_text()
        {
            var modelState = new ModelStateDictionary();

            var ms1 = new ModelState();
            ms1.Errors.Add("v1");
            ms1.Errors.Add("v2");
            modelState.Add("k", ms1);

            var ms2 = new ModelState();
            ms2.Errors.Add("v3");
            ms2.Errors.Add("v4");
            modelState.Add("k1", ms2);

            var actual = modelState.GetModelStateErrors();

            Assert.Equal("\"v1\", \"v2\", \"v3\", \"v4\"", actual);
        }

        [Fact]
        public void Should_convert_model_state_exception_to_text()
        {
            var modelState = new ModelStateDictionary();

            var ms1 = new ModelState();
            ms1.Errors.Add(new Exception("v1"));
            ms1.Errors.Add(new Exception("v2"));
            modelState.Add("k", ms1);

            var ms2 = new ModelState();
            ms2.Errors.Add(new Exception("v3"));
            ms2.Errors.Add(new Exception("v4"));
            modelState.Add("k1", ms2);

            var actual = modelState.GetModelStateErrors();

            Assert.Equal("\"v1\", \"v2\", \"v3\", \"v4\"", actual);
        }
    }
}