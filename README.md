# Proyecto de Juego de Carreras de Motos - Prueba de Concepto

Este repositorio contiene el código fuente y las pruebas unitarias para un juego de carreras de motos en desarrollo. El proyecto se centra en la personalización de las motos y su capacidad de competir en carreras.

## Programación Orientada a Objetos (OOP)

El proyecto sigue los principios de la Programación Orientada a Objetos (OOP), lo que significa que se estructura en torno a objetos y clases que representan conceptos del mundo real. A continuación, se describen algunos de los pilares de OOP que se utilizan en el proyecto:

1. **Abstracción**: Las clases como `Bike`, `Part`, `FrontWheel`, etc., modelan objetos del mundo real y abstraen sus propiedades y comportamientos.

2. **Encapsulación**: Se utilizan propiedades y métodos para encapsular el estado y el comportamiento de los objetos, ocultando los detalles internos y exponiendo solo lo necesario.

3. **Herencia**: Se aplican relaciones de herencia en las clases `FrontWheel`, `BackWheel`, `Chassis`, `Engine`, y `Muffler`, que heredan de la clase base `Part`.

4. **Polimorfismo**: El método `EquipPart` utiliza el polimorfismo para aceptar objetos de diferentes clases derivadas de `Part`.

## Framework de Pruebas NUnit

Para garantizar la calidad del código y la funcionalidad del juego, utilizamos NUnit como framework de pruebas unitarias. NUnit nos permite escribir y ejecutar pruebas de manera eficiente y automatizada. Las pruebas unitarias se encuentran en el proyecto de pruebas unitarias y se ejecutan regularmente para verificar que el código funcione según lo previsto.

## Desarrollo Dirigido por Pruebas (TDD)

El Desarrollo Dirigido por Pruebas (TDD) es una metodología de desarrollo que se utiliza en este proyecto. Esto significa que primero escribimos pruebas unitarias para una funcionalidad antes de implementarla. Luego, escribimos el código necesario para que las pruebas pasen. Este enfoque garantiza que el código esté bien probado y que cumpla con los requisitos especificados.

