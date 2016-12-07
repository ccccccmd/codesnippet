public static class ReflectionExtensions {

    public static void CreateDelegate<TDelegate>(this MethodInfo method, out TDelegate result) {
        result = (TDelegate)(object)Delegate.CreateDelegate(typeof(TDelegate), method);
    }
}

public static class RecordExtensions {

    private static class Cache<T> {
        public static Func<IRecord, string, T> Get;
    }

    static RecordExtensions() {
        typeof(IRecord).GetMethod("GetString").CreateDelegate(out Cache<string>.Get);
        typeof(IRecord).GetMethod("GetInt").CreateDelegate(out Cache<int>.Get);
        typeof(IRecord).GetMethod("GetLong").CreateDelegate(out Cache<long>.Get);
    }

    public static T Get<T>(this IRecord record, string field) {
        return Cache<T>.Get(record, field);
    }
}

//from http://blog.zhaojie.me/2014/05/zrx-quiz-1-answer.html