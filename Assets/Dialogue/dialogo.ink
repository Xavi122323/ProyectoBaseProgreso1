-> main

=== main ===
Que leyes ambientales se deberían aprobar?
    + [Proteccion de zonas hidricas]
        -> chosen("hidrico")
    + [Protección de bosques]
        -> chosen("bosques")
    + [Nada]
        -> chosen("nada")
        
=== chosen(law) ===
Elegiste {law}!
-> END