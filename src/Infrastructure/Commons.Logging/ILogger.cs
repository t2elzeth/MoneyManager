using System;
using JetBrains.Annotations;

namespace Commons.Logging;

public interface ILogger
{
    bool IsDebugEnabled { get; }

    bool IsInfoEnabled { get; }

    bool IsWarnEnabled { get; }

    bool IsErrorEnabled { get; }

    /// <summary>
    /// Determine if events at the specified level will be passed through
    /// to the log sinks.
    /// </summary>
    /// <param name="level">Level to check.</param>
    /// <returns>True if the level is enabled; otherwise, false.</returns>
    bool IsEnabled(LogLevel level);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
    /// </example>
    void Debug([StructuredMessageTemplate] string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
    /// </example>
    void Debug<T>([StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
    /// </example>
    void Debug<T0, T1>([StructuredMessageTemplate] string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
    /// </example>
    void Debug<T0, T1, T2>([StructuredMessageTemplate] string messageTemplate,
                           T0 propertyValue0,
                           T1 propertyValue1,
                           T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level and associated exception.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
    /// </example>
    void Debug([StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Debug(ex, "Swallowing a mundane exception.");
    /// </example>
    void Debug(Exception exception, [StructuredMessageTemplate] string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Debug(ex, "Swallowing a mundane exception.");
    /// </example>
    void Debug<T>(Exception exception, [StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Debug(ex, "Swallowing a mundane exception.");
    /// </example>
    void Debug<T0, T1>(Exception exception,
                       [StructuredMessageTemplate] string messageTemplate,
                       T0 propertyValue0,
                       T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Debug(ex, "Swallowing a mundane exception.");
    /// </example>
    void Debug<T0, T1, T2>(Exception exception,
                           [StructuredMessageTemplate] string messageTemplate,
                           T0 propertyValue0,
                           T1 propertyValue1,
                           T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Debug"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Debug(ex, "Swallowing a mundane exception.");
    /// </example>
    void Debug(Exception exception, [StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Info("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info([StructuredMessageTemplate] string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Info("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info<T>([StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Info("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info<T0, T1>([StructuredMessageTemplate] string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Info("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info<T0, T1, T2>([StructuredMessageTemplate] string messageTemplate,
                          T0 propertyValue0,
                          T1 propertyValue1,
                          T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level and associated exception.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Info("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info([StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Info(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info(Exception exception, [StructuredMessageTemplate] string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Info(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info<T>(Exception exception, [StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Info(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info<T0, T1>(Exception exception,
                      [StructuredMessageTemplate] string messageTemplate,
                      T0 propertyValue0,
                      T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Info(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info<T0, T1, T2>(Exception exception,
                          [StructuredMessageTemplate] string messageTemplate,
                          T0 propertyValue0,
                          T1 propertyValue1,
                          T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Information"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Info(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
    /// </example>
    void Info(Exception exception, [StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Warn("Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn([StructuredMessageTemplate] string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Warn("Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn<T>([StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Warn("Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn<T0, T1>([StructuredMessageTemplate] string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Warn("Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn<T0, T1, T2>([StructuredMessageTemplate] string messageTemplate,
                          T0 propertyValue0,
                          T1 propertyValue1,
                          T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level and associated exception.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Warn("Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn([StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Warn(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn([StructuredMessageTemplate] Exception exception, string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Warn(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn<T>(Exception exception, [StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Warn(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn<T0, T1>(Exception exception,
                      [StructuredMessageTemplate] string messageTemplate,
                      T0 propertyValue0,
                      T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Warn(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn<T0, T1, T2>(Exception exception,
                          [StructuredMessageTemplate] string messageTemplate,
                          T0 propertyValue0,
                          T1 propertyValue1,
                          T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Warning"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Warn(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
    /// </example>
    void Warn(Exception exception, [StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error([StructuredMessageTemplate] string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error<T>([StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error<T0, T1>([StructuredMessageTemplate] string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error<T0, T1, T2>([StructuredMessageTemplate] string messageTemplate,
                           T0 propertyValue0,
                           T1 propertyValue1,
                           T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level and associated exception.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error([StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error(Exception exception, [StructuredMessageTemplate] string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error<T>(Exception exception, [StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error<T0, T1>(Exception exception,
                       [StructuredMessageTemplate] string messageTemplate,
                       T0 propertyValue0,
                       T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error<T0, T1, T2>(Exception exception,
                           [StructuredMessageTemplate] string messageTemplate,
                           T0 propertyValue0,
                           T1 propertyValue1,
                           T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Error"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
    /// </example>
    void Error(Exception exception, [StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Fatal("Process terminating.");
    /// </example>
    void Fatal([StructuredMessageTemplate] string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Fatal("Process terminating.");
    /// </example>
    void Fatal<T>([StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Fatal("Process terminating.");
    /// </example>
    void Fatal<T0, T1>([StructuredMessageTemplate] string messageTemplate, T0 propertyValue0, T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Fatal("Process terminating.");
    /// </example>
    void Fatal<T0, T1, T2>([StructuredMessageTemplate] string messageTemplate,
                           T0 propertyValue0,
                           T1 propertyValue1,
                           T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level and associated exception.
    /// </summary>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Fatal("Process terminating.");
    /// </example>
    void Fatal([StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <example>
    /// Log.Fatal(ex, "Process terminating.");
    /// </example>
    void Fatal(Exception exception, [StructuredMessageTemplate] string messageTemplate);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Fatal(ex, "Process terminating.");
    /// </example>
    void Fatal<T>(Exception exception, [StructuredMessageTemplate] string messageTemplate, T propertyValue);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Fatal(ex, "Process terminating.");
    /// </example>
    void Fatal<T0, T1>(Exception exception,
                       [StructuredMessageTemplate] string messageTemplate,
                       T0 propertyValue0,
                       T1 propertyValue1);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    /// <example>
    /// Log.Fatal(ex, "Process terminating.");
    /// </example>
    void Fatal<T0, T1, T2>(Exception exception,
                           [StructuredMessageTemplate] string messageTemplate,
                           T0 propertyValue0,
                           T1 propertyValue1,
                           T2 propertyValue2);

    /// <summary>
    /// Write a log event with the <see cref="LogLevel.Fatal"/> level and associated exception.
    /// </summary>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
    /// <example>
    /// Log.Fatal(ex, "Process terminating.");
    /// </example>
    void Fatal(Exception exception, [StructuredMessageTemplate] string messageTemplate, params object[] propertyValues);


    ILogContext PushContext(string name, object context);
}