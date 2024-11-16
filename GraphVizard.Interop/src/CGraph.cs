using System.Runtime.InteropServices;

namespace GraphVizard.Interop;

public static partial class CGraph
{
    public const string LibCGraph = "cgraph";
    
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

    public const int AGRAPH = 0, AGNODE = 1, AGEDGE = 2, AGOUTEDGE = AGEDGE, AGINEDGE = 3;
    
    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agopen(string label, byte desc, IntPtr unusedNull);

    [LibraryImport(LibCGraph)]
    public static partial void agclose(IntPtr g);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agnode(IntPtr g, string? name, [MarshalAs(UnmanagedType.I4)] bool create);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agedge(IntPtr g, IntPtr tail, IntPtr head, string? identifier,
        [MarshalAs(UnmanagedType.I4)] bool create);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agmemread(string cp);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial string? agget(IntPtr n, string name);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial string? agxget(IntPtr n, IntPtr idx);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void agset(IntPtr n, string name, string? value);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void agxset(IntPtr n, IntPtr idx, string? value);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agsubg(IntPtr g, string name, [MarshalAs(UnmanagedType.I4)]  bool create);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agattr(IntPtr g, int type, string name, string? def);

    [LibraryImport(LibCGraph, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr agnameof(IntPtr n);
}