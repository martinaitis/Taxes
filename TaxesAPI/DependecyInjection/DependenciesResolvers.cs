using TaxesData;
using TaxesLog;

public delegate ISourceProvider SourceProviderResolver(string key);
public delegate ILogger LoggerResolver(string key);