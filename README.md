# Number Selector

###### Prueba técnica Unity Developer Innovamat por Adrià Puigdellívol

### La clase _NumberManager_

La clase _NumberManager_ es la encargada de gestionar el estado del juego. Almacena el número correcto, los intentos, se encarga de actualizar el panel de aciertos y fallos y es la que ejecuta las corrutinas del bucle de juego. 

_NumberManager_ es un **singleton**. Se ha escogido este arquetipo de diseño porque permite delegar funcionalidad a otras clases mientras se mantiene la gestión del juego. Por ejemplo, gracias a este arquetipo podemos dejar que cada botón gestione su propio click, pero que pueda notificar al _manager_ de ello. De esta manera, en el manager solo tenemos código directamente relacionado con el bucle principal del juego.

El **singleton** también permite que toda la aplicación pueda acceder a los atributos y funciones publicas de la clase. Lo que ha sido útil para conocer cual es el número correcto en todo momento sin tener que replicar variables.

### Las componentes _Fade_

Se han creado tres componentes _Fade_: _FadeText_, _FadeImage_ y _FadeButton_. Que extienden de los componentes nativos de Unity _Text_, _Image_ y _Button_ respectivamente. Estas clases añaden la funcionalidad de aparecer y desvanecerse (_fade in_ y _fade out_) a los componentes de los que heredan. 

Al implementar la funcionalidad directamente en los componentes, se ha podido reutilizar la animación en toda la aplicación sin tener que replicar código. 

### La función _numberToText_

```c#
	private string numberToText(int num)
    {
        if (num <= 29)
            return new string[] {"", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", 
                                 "SIETE", "OCHO", "NUEVE", "DIEZ", "ONCE", "DOCE", 
                                 "TRECE", "CATORCE", "QUINCE", "DIECISÉIS", "DIECISIETE", 
                                 "DIECIOCHO", "DIECINUEVE", "VEINTE", "VEINTIUNO", 
                                 "VEINTIDÓS", "VEINTITRÉS", "VEINTICUATRO", 
                                 "VEINTICINCO", "VEINTISÉIS", "VEINTISIETE", 
                                 "VEINTIOCHO", "VEINTINUEVE"}[num];
        else if (num <= 99)
        {
            string str = new string[] {"TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", 
                                       "SETENTA", "OCHENTA", "NOVENTA"}[num / 10 - 3];
            if ((num % 10) != 0) str += " Y " + numberToText(num % 10);
            return str;
        }
        else if (num == 100)
            return "CIEN";
        else if (num <= 199)
            return "CIENTO " + numberToText(num % 100);
        else if (num <= 999)
            return new string[] { "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", 
                                 "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", 
                                 "OCHOCIENTOS", "NOVECIENTOS" }[num / 100 - 2] + " " + 									numberToText(num % 100);
        else if (num <= 1999)
            return "MIL " + numberToText(num % 1000);
        else if (num <= 999999)
            return numberToText(num / 1000) + " MIL " + numberToText(num % 1000);
        else if (num <= 1999999)
            return "UN MILLÓN " + numberToText(num % 1000000);
        else
            return numberToText(num / 1000000) + " MILLONES " + numberToText(num % 1000000);
    }

```

La función _numberToText_ se encuentra en la clase _NumberText_ y, como su nombre indica es la encargada de transformar cualquier número entero (*int*) mayor que cero en su nombre (_string_) en español.

Para poder realizar esta transformación se ha implementado una función recursiva, ya que los nombres de los números en español estan formados por partes fácilmente reutilizables.

#### Importante!

Esta función no soporta el numero **0**, ya que rompería funcionalidad en la gran mayoría de múltiplos de diez. 

### El clase _Config_

La clase _Config_ es una clase estática que almacena variables _readonly_ que se utilizan a lo largo de toda la aplicación. Se ha escogido esta implementación por dos motivos:

* Permite reutilizar valores como el tiempo de las animaciones de aparecer y desvanecerse sin tener que replicarlo en cada una de las clases _Fade_.
* Permite modificar atributos importantes como el rango de valores de los números o el color de los botones sin tener que buscarlos en diversos ficheros.

### EXTRA: El selector de dificultad

Se ha implementado una funcionalidad extra no requerida: Un **selector de dificultad**. Esta funcionalidad modifica ligeramente el ciclo de ejecución que se pedía en el enunciado: 

Cuando se inicia la aplicación, antes de que aparezca el primer número random, se le mostrará al usuario un selector de dificultad con tres opciones: *Fácil*, *Normal* y *Difícil*. Al hacer click en una de las tres opciones, el selector de dificultad se desvanecerá y aparecerá el primer número. A partir de este punto el funcionamiento de la aplicación es el definido por el enunciado. Una vez seleccionada la dificultad, no se puede cambiar.

El nivel de dificultad escogido modifica el rango de valores que pueden tomar los números aleatorios. En el nivel **Fácil** solo aparecerán números entre el 1 y el 9, ambos incluidos; en el nivel **Normal** serán entre el 1 y el 999; y en el nivel **Difícil** los números podrán llegar hasta 9.999.999!

Se ha decidido implementar esta funcionalidad para demostrar las capacidades de la función _numberToText_. Además, gracias a los componentes _Fade_ prácticamente no se ha tenido que crear código extra para esta funcionalidad. 