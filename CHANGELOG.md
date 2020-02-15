# Changelog
Todos los cambios notables serán documentados en este archivo.
El formato esta basado en [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
y este proyecto se adhiere a [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [1.0.6] - 2020-02-15
### Agregado:
- Boton con enlace a este registro de cambios de versión.
## [1.0.5] - 2020-02-15
### Agregado:
- Pantalla de incio.
## [1.0.4] - 2020-02-15
### Cambios:
- Separada la capa de sonido de la capa de interfaz. Esto resulto en la reduccion del lag de inicializacion y el uso de memoria.
### Removido:
- Importación no utilizadas y espacios blancos excesivos.
## [1.0.3] - 2020-02-14
### Cambios:
- Sentry actualizado.
- Retroalimentación optimizada.
### Fallos corregidos:
- Validacion del correo en el formulario de retroalimentación. No incluir arroba provocaba un error 400 bad post.
- Corregida mala practica en el uso de Sentry.CaptureEvent envuelto en un try-catch siendo lo optimo Sentry.CaptureException.
## [1.0.2] - 2020-01-23
### Agregado:
- Formulario de retroalimentación.
- Sentry ahora reporta la version en la que se producen fallos.
- El usuario puede reportar la palabra para asegurar la calidad de la base de datos. (Palabras malsonantes)
### Fallos corregidos:
- Corregido tamaño del boton de retroalimentación.
## [1.0.1] - 2020-01-23
### Agregado:
- Formulario de configuracion.
- Integrado servicio de rastreo de errores de Sentry.io
- Efecectos de sonido de clic.
- Las letras cambian de color segun aciertos/fallos.
- El puntaje puede ser reinciado a traves de las configuraciones.
- Antialiasing puede ser apagado o encendido desde las configuraciones.
- Implementada enorme base de datos de palabras en español, llevando registro de apariciones de palabras individuales y si se acertó o fallo el adivinar la palabra.
- Muñeco de ahorcado con siete etapas diferentes.
- Arte en el boton de configuraciones.
- Efectos de sonido de acierto, fallo, victoria, y perder.
- Documentacion del codigo mejorada. 
- Historial de ultimas palabras.
- Enlace de donaciones de paypal.
### Cambios:
- Movido struct de historial a archivo cs individual.
- Optimizadas las llamadas a UpdateScreen().
### Fallos corregidos:
- Corregido doble sonido de click al hacer un solo click.
- Presionar la misma letra repite el sonido de acierto/fallo.
- Duplicacion de puntos.
- Ding de windows al presionar teclas.
### Removido:
- Imagen de tumba.
## [1.0.0]
- Version Inicial, funcionalidad basica y con fallos.


[unreleased]: https://github.com/ezrillex/Ahorcado/commits/master
[1.0.5]: https://github.com/ezrillex/Ahorcado/commit/83b71858c5ca81da41951a85243accf4f3afd7d9?diff=unified
[1.0.4]: https://github.com/ezrillex/Ahorcado/commit/937cde5d5592fdc469c82b5f98b53fe228345c1a?diff=unified
[1.0.3]: https://github.com/ezrillex/Ahorcado/commit/2d09f2954efbcb31dad2ecaeef4d879ba6906f23?diff=unified
[1.0.2]: https://github.com/ezrillex/Ahorcado/releases/tag/1.0.2
[1.0.1]: https://github.com/ezrillex/Ahorcado/releases/tag/1.0.1
[1.0.0]: https://github.com/ezrillex/Ahorcado/commit/cefc0a3e1276dcbe4b1ab970e711160e6ec8a3e6?diff=unified
