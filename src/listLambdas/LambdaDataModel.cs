
namespace listLambdas.Models
{

    public class LambdaDataModel
    {
        public string FunctionName { get; set;} = "";
        public string FunctionDescription {get; set;} = "";
        public string FunctionARN {get; set;} = "";
        public string FunctionHandler {get; set;} = "";
        //The below attribute will need to be converted to a string.
        public string FunctionRuntime {get; set;} = "";
        public string FunctionLastModifiedOnDate {get; set;} = "";
        public string FunctionLayers {get; set;} = "";
        public string FunctionRole {get; set;} = "";
    }
}