namespace Common.Logging.MicrosoftLogging
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;

    public static class CommonLoggingExtensions
    {
        /// <summary>
        /// Adds the common.logging.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <returns>The <see cref="ILoggerFactory"/> with added common.logging provider</returns>
        public static ILoggerFactory AddCommonLogging(this ILoggerFactory factory)
            => factory.AddCommonLogging(new CommonLoggingProviderOptions());


        /// <summary>
        /// Adds the common.logging logging provider.
        /// </summary>
        /// <param name="factory">The logger factory.</param>
        /// <param name="options">The options for common.logging provider.</param>
        /// <returns>The <see cref="ILoggerFactory"/> after adding the common.logging provider.</returns>
        public static ILoggerFactory AddCommonLogging(this ILoggerFactory factory, CommonLoggingProviderOptions options)
        {
            factory.AddProvider(new CommonLoggingProvider(options));
            return factory;
        }


#if !NETCOREAPP1_1
        /// <summary>
        /// Adds the common.logging logging provider.
        /// </summary>
        /// <param name="builder">The logging builder instance.</param>
        /// <returns>The <see ref="ILoggingBuilder" /> passed as parameter with the new provider registered.</returns>
        public static ILoggingBuilder AddCommonLogging(this ILoggingBuilder builder)
        {
            var options = new CommonLoggingProviderOptions();

            return builder.AddCommonLogging(options);
        }

        /// <summary>
        /// Adds the common.logging logging provider.
        /// </summary>
        /// <param name="builder">The logging builder instance.</param>
        /// <param name="log4NetConfigFile">The common.logging Config File.</param>
        /// <returns>The <see ref="ILoggingBuilder" /> passed as parameter with the new provider registered.</returns>
        public static ILoggingBuilder AddCommonLogging(this ILoggingBuilder builder, CommonLoggingProviderOptions options)
        {
            builder.Services.AddSingleton<ILoggerProvider>(new CommonLoggingProvider(options));

            return builder;
        }
#endif
    }
}
