namespace MarcoAntonioGrison
{
    class Program
    {
        class Candidatos
        {
            public string? Nome;
            public int QntdVotos = 1;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Informe a quantidade de votos:");
                List<Candidatos> votos = new List<Candidatos>();
                Candidatos voto;
                int qtdVotos = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i < qtdVotos + 1; i++)
                {
                    Console.WriteLine($"Informe o nome do candidato para o voto nº{i}:");
                    string nomeCandidato = Console.ReadLine()!.ToUpper();

                    if(string.IsNullOrWhiteSpace(nomeCandidato))
                    {
                        Console.WriteLine("Digite um nome!");
                        return;
                    }

                    voto = new Candidatos { Nome = nomeCandidato };
                    if (!votos.Exists(v => v.Nome == voto.Nome))
                        votos.Add(voto);
                    else
                        votos.Where(v => v.Nome?.ToUpper() == voto.Nome.ToUpper()).FirstOrDefault()!.QntdVotos++;
                }
                Console.WriteLine($"O candidato mais votado é o(a): {VencedorEleicao(votos)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
        private static string VencedorEleicao(List<Candidatos> votos)
        {
            return votos.Where(v => v.QntdVotos == votos.Max(c => c.QntdVotos))
                        .OrderBy(v => v.Nome)
                        .FirstOrDefault()!.Nome!
                        .ToString();
        }
    }
}