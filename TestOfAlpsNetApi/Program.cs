// See https://aka.ms/new-console-template for more information
using alps.net.api.parsing;
using alps.net.api.StandardPASS;

Console.WriteLine("Start Loading PASS Models and Ontologies.");

IPASSReaderWriter io = PASSReaderWriter.getInstance();

// Prepare the paths to the structure-defining owl files
IList<string> paths = new List<string>
{
    "C:/Users/oster/Documents/SPSEAE/OWL Ontologies/ALPS_ONT-main/ALPS_ont_v_0.8.0.owl",
    "C:/Users/oster/Documents/SPSEAE/OWL Ontologies/Standard-PASS-Ontology-main/standard_PASS_ont_dev.owl",
};
// Load these files once (no future calls neded)
io.loadOWLParsingStructure(paths);

IList<IPASSProcessModel> models = io.loadModels(new List<string> { "C:/Users/oster/Documents/SPSEAE/VisioDump/Urlaubsantrag_Discord_Übung.owl" });

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