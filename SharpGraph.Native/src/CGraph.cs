using System.Runtime.InteropServices;
using static SharpGraph.Native.GraphViz;

namespace SharpGraph.Native;

public static partial class CGraph
{
    public static IntPtr AGDATA(IntPtr n)
    {
        /*
         * Imitates C macro: #define AGDATA(obj) (((Agobj_t *)(obj))->data)
         * Assumes 'n' is a pointer to struct Agobj_s
         * offsetof(Agobj_s, Agobj_s::data) == 16
         */

        return n + 16;
    }

    public static Position ND_coord(IntPtr n)
    {
        /*
         * Imitates C macro: #define ND_coord(n) (((Agnodeinfo_t*)AGDATA(n))->coord)
         * Assumes 'n' is pointer to struct Agnodeinfo_t
         * offsetof(Agnodeinfo_t, Agnodeinfo_t::coord) == 32
         */

        var data = Marshal.ReadIntPtr(AGDATA(n));
        var ptr = data + 32;
        return Marshal.PtrToStructure<Position>(ptr);
    }
    
    [LibraryImport(LibGraphViz, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agopen(string label, byte desc, IntPtr unusedNull);

    [LibraryImport(LibGraphViz)]
    public static partial void agclose(IntPtr g);

    [LibraryImport(LibGraphViz, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agnode(IntPtr g, string? name, [MarshalAs(UnmanagedType.I4)] bool create);

    [LibraryImport(LibGraphViz, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agedge(IntPtr g, IntPtr tail, IntPtr head, string? identifier,
        [MarshalAs(UnmanagedType.I4)] bool create);

    [LibraryImport(LibGraphViz, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agmemread(string cp);

    [LibraryImport(LibGraphViz, StringMarshalling = StringMarshalling.Utf8)]
    public static partial string? agget(IntPtr n, string a);
}