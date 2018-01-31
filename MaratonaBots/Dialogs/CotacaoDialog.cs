using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace MaratonaBots.Dialogs
{
    [Serializable]
    [LuisModel("", "")]
    public class CotacaoDialog : LuisDialog<object>
    {
      
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result) {
            await context.PostAsync($"Desculpe não consegui entender a frase {result.Query}");
        }


        [LuisIntent("Sobre")]
        public async Task Sobre(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Eu sou um bot e estou sempre aprendendo. Tenha paciência comigo.");
        }

        [LuisIntent("Cumprimento")]
        public async Task Cumprimento(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Eu sou um bot que faz cotação de moedas.");
        }


        [LuisIntent("Cotacao")]
        public async Task Cotacao(IDialogContext context, LuisResult result)
        {
            var moedas = result.Entities?.Select(e => e.Entity);
            await context.PostAsync($"Eu farei uma cotação para as moedas {String.Join(" , ",moedas.ToArray())}");
        }
    }
}