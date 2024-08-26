import java.util.logging.Formatter;
import java.util.logging.LogRecord;

public class LogFormatter extends Formatter {
	@Override
	public String format(LogRecord record) {
		return String.format("[%s] %s: %s%n", record.getLevel(), record.getLoggerName(), record.getMessage());
	}
}
