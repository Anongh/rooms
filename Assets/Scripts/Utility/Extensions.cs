using UnityEngine;

public static class VectorExtensions {
    public static Vector3 WithX(this Vector3 v, float x) {
        v.x = x;
        return v;
    }

    public static Vector3 WithY(this Vector3 v, float y) {
        v.y = y;
        return v;
    }

    public static Vector3 WithZ(this Vector3 v, float z) {
        v.z = z;
        return v;
    }
}

public static class ColorExtensions {
    public static Color WithR(this Color c, float r) {
        c.r = r;
        return c;
    }

    public static Color WithG(this Color c, float g) {
        c.g = g;
        return c;
    }

    public static Color WithB(this Color c, float b) {
        c.b = b;
        return c;
    }

    public static Color WithA(this Color c, float a) {
        c.a = a;
        return c;
    }
}
