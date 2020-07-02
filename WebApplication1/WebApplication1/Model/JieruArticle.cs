using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class JieruArticle
    {
        public string ArticleId { get; set; }
        public string ArticleAuthor { get; set; }
        public string ArticleContent { get; set; }
        public string ArticleSource { get; set; }
        public DateTime? ArticleDatetime { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public sbyte? Shzt { get; set; }
        public sbyte? Sfkdj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Id { get; set; }
    }
}
