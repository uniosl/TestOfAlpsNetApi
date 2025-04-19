// See https://aka.ms/new-console-template for more information
using alps.net.api.parsing;
using alps.net.api.StandardPASS;

// Creating paths inside project
string currentDirectory = Directory.GetCurrentDirectory();
string passPath = Path.Combine(currentDirectory, "PASS_Files", "ONTs", "standard_PASS_ont_dev.owl");
string alpsPath = Path.Combine(currentDirectory, "PASS_Files", "ONTs", "ALPS_ont_v_0.8.0.owl");
string urlaubAntragOWL = Path.Combine(currentDirectory, "PASS_Files", "Models", "Urlaubsantrag_Discord_Uebung.owl");

Console.WriteLine("Start Loading PASS Models and Ontologies.");

IPASSReaderWriter io = PASSReaderWriter.getInstance();

// Prepare the paths to the structure-defining owl files
IList<string> paths = new List<string>
{
    passPath,
    alpsPath,
};
// Load these files once (no future calls neded)
io.loadOWLParsingStructure(paths);

IList<IPASSProcessModel> models = io.loadModels(new List<string> { urlaubAntragOWL });

IDictionary<string, IPASSProcessModelElement> processModelElements = models[0].getAllElements();

foreach (KeyValuePair<string, IPASSProcessModelElement> kvp in processModelElements)
{
    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
}

/*
IDictionary<string, ISubject> startSubjects = models[0].getStartSubjects();

foreach (KeyValuePair<string, ISubject> sbj in startSubjects)
{
    Console.WriteLine($"Key: {sbj.Key}, Value: {sbj.Value}");
}

Console.WriteLine("Loaded PASS Models and Ontologies.");
*/