import random

def obtener_numero_secreto():
    return random.randint(1, 100)

def juego_adivinanza():
    print("¡Bienvenidos al juego de adivinanza de números!")
    print("Cada jugador tratará de adivinar el número secreto entre 1 y 100.")
    
    jugadores = [input("Nombre del Jugador 1: "), input("Nombre del Jugador 2: ")]
    intentos_maximos = 10

    numero_secreto = obtener_numero_secreto()
    print(f"\n¡El número secreto ha sido seleccionado! {jugadores[0]} y {jugadores[1]}, ¡a adivinar!")

    intentos = {jugadores[0]: 0, jugadores[1]: 0}
    turno = 0

    while True:
        jugador_actual = jugadores[turno % 2]
        intento = int(input(f"\n{jugador_actual}, ingresa tu adivinanza (1-100): "))

        if intento < 1 or intento > 100:
            print("¡La adivinanza debe estar entre 1 y 100!")
            continue

        intentos[jugador_actual] += 1

        if intento == numero_secreto:
            print(f"\n¡Felicidades {jugador_actual}! Adivinaste el número secreto {numero_secreto} en {intentos[jugador_actual]} intentos.")
            break
        elif intentos[jugador_actual] >= intentos_maximos:
            print(f"\n{jugador_actual} ha alcanzado el límite de intentos ({intentos_maximos}).")
            break
        elif intento < numero_secreto:
            print("El número secreto es mayor que tu adivinanza.")
        else:
            print("El número secreto es menor que tu adivinanza.")
        
        turno += 1

    print("\n¡Fin del juego!")

# Ejecutar el juego
if __name__ == "__main__":
    juego_adivinanza()
