using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SimonMemoryGame
{
    public partial class SimoneForm : Form
    {
        // Entero que representa el numero de rondas que va el jugador

        private int roundNumber;

        // Booleano que se usa para flaggear si se esta replicando el patron de la lista en los botones (simon esta hablando)

        private bool isSimonSpeaking;

        // Lista de enteros que conforma el patron entero, todos los enteros de esta lista solo pueden contener desde el numero 0 al 4 gracias a Random.

        private List<int> colorPattern;

        // Random para generar lo que simon va a decir (elementos del patron)
        // va desde 0 a 4, para representar cada color (Rojo = 0, Azul = 1, Amarillo = 2, Verde = 3)

        private Random randomGenerator;


        // Inicializacion de lista y instancia de random (lista tiene que estar inicializada para albergar numeros
        // Random tiene que estar inicializado para que genere numeros random.

        public SimoneForm()
        {
            InitializeComponent();
            colorPattern = new List<int>();
            randomGenerator = new Random();
        }

        // por cada eleccion / boton que tiene el jugador, si el jugador clickea dicho boton llama a esta funcion dependiendo del color que representa el boton
        // que clickeo, de ahi chequeamos: 

        void CheckIfPlayerChoiceIsCorrect(int numberColor)
        {

            // Si simon esta hablando, retornamos, no es turno del jugador.

            if (isSimonSpeaking) return;

            // Explicacion: la lista contiene colores, y cada posicion de la lista corresponde a un numero de ronda, por ej: ronda 1 rojo, lista[rojo], ronda 2 azul lista[rojo,azul]... etc
            // entonces se puede decir que la ronda 1 tiene el color rojo, la ronda 2 el azul, y asi, entonces, aca chequeamos si el jugador apreto un boton el cual corresponde
            // a la ronda que actualmente esta intentando adivinar, si es asi, seguimos a la proxima ronda (el patron es obviamente, al ser la lista, un conjunto de rondas.)

            if (colorPattern[roundNumber] == numberColor)
            {
                roundNumber++;
            }
            else // si el jugador adivino incorrectamente la ronda que estaba adivinando, pierde
            {
                MessageBox.Show($"You failed, final score: {colorPattern.Count.ToString()}", "GAME OVER");
                roundNumber = 0;
                colorPattern = new List<int>();
                new Thread(StartASimonRound).Start();
            }

            // Si el padron entero, que es un conjunto de rondas, fue adivinado por completo,
            // significa que round number llego al mismo valor numerico que las posiciones de la lista (porque basicamente, recorrio la lista entera.
            // esto significa que el patron completo fue correctamente replicado, por lo cual, agregamos un nuevo color a la lista (lo cual cambia el patron)
            // seteamos el numero de rondas a 0 para que se tenga que replicar el patron desde el comienzo y se llama a un nuevo hilo a que ejecute otra ronda.

            if (roundNumber >= colorPattern.Count)
            {
                colorPattern.Add(randomGenerator.Next(0, 4));
                roundNumber = 0;
                new Thread(StartASimonRound).Start();
            }

            // seteamos el valor del label al total de rondas adivinadas, restando 1 porque como los indices de los arrays, los de la lista tambien son basados en 0, o 0 based.

            ScoreLabel.Text = ($"Score: {(colorPattern.Count - 1).ToString()}");
        }


        // la ronda siempre empieza con " simon " diciendo el patron que tiene albergado en la lista

        void StartASimonRound()
        {
            // para evitar que los hilos se interfieran, si un hilo llama por error a StartASimonRound() (o el jugador clickea un boton mientras simon habla)
            // y simon esta hablando, Cuando Se chequea la respuesta directamente retorna porque no es el turno del jugador.

            isSimonSpeaking = true;

            // por cada color que tenemos en el patron/lista -> chequeamos el color que tenemos en la iteracion correspondiente
            // -> cambiamos el color del boton que representa ese color, llamamos a dormir al hilo correspondiente por 190milisegundos
            // -> volvemos a cambiar al =color normal, dando el efecto de que simon " esta hablando " y repitiendo el patron.

            foreach (int colorNumber in colorPattern)
            {
                switch (colorNumber)
                {
                    case 0:

                        Red.BackColor = Color.Red;
                        Thread.Sleep(190);
                        Red.BackColor = Color.Black;

                        break;
                    case 1:

                        Blue.BackColor = Color.Blue;
                        Thread.Sleep(190);
                        Blue.BackColor = Color.Black;

                        break;
                    case 2:

                        Yellow.BackColor = Color.Yellow;
                        Thread.Sleep(190);
                        Yellow.BackColor = Color.Black;

                        break;
                    case 3:

                        Green.BackColor = Color.Green;
                        Thread.Sleep(190);
                        Green.BackColor = Color.Black;
                        break;
                }

                Thread.Sleep(200);
            }

            // Simon dejo de hablar / se dejo de reproducir el patron, setteamos la bandera en falso.

            isSimonSpeaking = false;
        }

        // onClickListeners / clickHandlers / funciones que manejan los eventos de click de cada boton

        private void Red_Click(object sender, EventArgs e)
        {
            CheckIfPlayerChoiceIsCorrect(0);
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            CheckIfPlayerChoiceIsCorrect(1);
        }

        private void Yellow_Click(object sender, EventArgs e)
        { 
            CheckIfPlayerChoiceIsCorrect(2);
        }

        private void Green_Click(object sender, EventArgs e)
        {        
            CheckIfPlayerChoiceIsCorrect(3);
        }


        // Cuando se inicializa la forma, agregamos el primero numero al patron y empezamos el juego con un nuevo hilo.

        private void SimoneForm_Load(object sender, EventArgs e)
        {
            colorPattern.Add(randomGenerator.Next(0, 4));
            new Thread(StartASimonRound).Start();
        }
    }
}

