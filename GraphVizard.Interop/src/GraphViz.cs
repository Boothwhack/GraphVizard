using System.Runtime.InteropServices;

namespace GraphVizard.Interop;

public static partial class GraphViz
{
    public static class Context
    {
        private static IntPtr? _contextSingleton;

        public static IntPtr GetContext()
        {
            if (_contextSingleton is { } context)
                return context;
            context = gvContext();
            _contextSingleton = context;
            return context;
        }
    }
    
    public const string LibGraphViz = "gvc";

    [LibraryImport(LibGraphViz)]
    public static partial IntPtr gvContext();
    
    [LibraryImport(GraphViz.LibGraphViz, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void gvLayout(IntPtr gvc, IntPtr g, string format);

    [LibraryImport(GraphViz.LibGraphViz, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void gvRenderFilename(IntPtr gvc, IntPtr g, string typ, string path);

    [LibraryImport(LibGraphViz, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void gvRenderData(IntPtr gvc, IntPtr g, string format, out IntPtr data, out uint length);

    [LibraryImport(LibGraphViz)]
    public static partial void gvFreeRenderData(IntPtr data);
}