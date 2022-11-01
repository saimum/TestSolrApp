namespace TestSolrApp.SolrResponseModels
{
    public class CategoryCoreResponseTemplate
    {
        //Paste as JSON classes
        public class Rootobject
        {
            public Responseheader responseHeader { get; set; }
            public Response response { get; set; }
        }

        public class Responseheader
        {
            public int status { get; set; }
            public int QTime { get; set; }
            public Params _params { get; set; }
        }

        public class Params
        {
            public string q { get; set; }
            public string indent { get; set; }
            public string rows { get; set; }
            public string wt { get; set; }
        }

        public class Response
        {
            public int numFound { get; set; }
            public int start { get; set; }
            public List<Doc> docs { get; set; }
        }

        public class Doc
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public long _version_ { get; set; }
        }

    }
}
