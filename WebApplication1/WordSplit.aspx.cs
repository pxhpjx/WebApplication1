using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Lucene.Net.Analysis;

namespace WebApplication1
{
    public partial class WordSplit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ddd = GetSplitString("隆山家常菜");
        }


        private Analyzer _analyzer = null;
        public Analyzer analyzer
        {
            get
            {
                _analyzer = new Lucene.Net.Analysis.PanGu.PanGuAnalyzer();
                return _analyzer;
            }
        }

        private List<string> GetSplitString(string searchText)
        {
            List<string> listResult = new List<string>();
            TokenStream tokenStream = analyzer.TokenStream(searchText, new StringReader(searchText));
            //Boolean hasNext = tokenStream.IncrementToken();
            ////Lucene.Net.Analysis.Tokenattributes.TermAttributeImpl ita;
            //while (hasNext)
            //{
            //    //ita = tokenStream.GetAttribute<Lucene.Net.Analysis.Tokenattributes.TermAttributeImpl>();

            //    //listResult.Add(tokenStream());
            //    hasNext = tokenStream.IncrementToken();
            //}

            Token token = tokenStream.Next();
            while (token != null)
            {
                listResult.Add(token.TermText());
                token = tokenStream.Next();
            }
            return listResult;
        }    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    }
}