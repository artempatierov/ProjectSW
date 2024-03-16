#include <iostream>
#include <Windows.h>
#include <chrono>
#include <thread>
#include <cstdlib>
#include <cwchar>
using namespace std;

const int WIDTH = 155;
const int HIEGHT = 55;
const int DICE = 10;
const int COUNT_COORD = 40;
const int PROPERTY_POSITION = 40;
char map[] =
"#########################################################################################################################################################\n"
"#             #             #             #             #             #             #            #             #             #            #             #\n"
"#             #             #             #             #             #             #            #             #             #            #             #\n"
"#             #             #             #             #             #             #            #             #             #            #             #\n"
"#             #             #             #             #             #             #            #             #             #            #             #\n"
"#########################################################################################################################################################\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"###############                                                                                                                           ###############\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"###############                                                                                                                           ###############\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"###############                                                                                                                           ###############\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"###############                                                                                                                           ###############\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"###############                                                                                                                           ###############\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"###############                                                                                                                           ###############\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"###############                                                                                                                           ###############\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"###############                                                                                                                           ###############\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#             #                                                                                                                           #             #\n"
"#########################################################################################################################################################\n"
"#             #             #             #             #             #             #            #             #             #            #             #\n"
"#             #             #             #             #             #             #            #             #             #            #             #\n"
"#             #             #             #             #             #             #            #             #             #            #             #\n"
"#             #             #             #             #             #             #            #             #             #            #             #\n"
"#########################################################################################################################################################\n";

void gotoxy(int x, int y) {
    COORD pos = { x, y };
    HANDLE output = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleCursorPosition(output, pos);
}
int randomDice() {
    srand(time(0));
    int min = 1;
    int max = 6;
    int K = max - min + 1;
    int r = rand() % K + min;
    return r;
}
int randomStart() {
    srand(time(0));
    int min = 1;
    int max = 2;
    int K = max - min + 1;
    int r = rand() % K + min;
    return r;
}
int throwADiceOne() {
    int dice;
    dice = randomDice();
    return dice;
}
int throwADiceTwo() {
    int dice;
    dice = randomDice();
    return dice;
}


int main(){
    HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);
    CONSOLE_CURSOR_INFO cci = { 100, 0 };
    SetConsoleCursorInfo(h, &cci);
    system("color b");
    bool isRunning = true;
    bool move = true;
    short takeATurn = 0;
    int diceOne = 0;
    int diceTwo = 0;
    int diceTotal = 0;
    int diceTotalComp = 0;
    int accumulator = 0;
    int accumulatorComp = 0;
    int moneyPlayer = 1500;
    int moneyComputer = 1500;
    int playerMoney[] = { moneyPlayer };
    int ComputerMoney[] = { moneyComputer };
    int propertyPlayer = 0;
    int propertyComputer = 0;
    int playerProperty[] = { propertyPlayer };
    int computerProperty[] = { propertyComputer };
    int propertyBuy = 0;
    int turn = randomStart();
    int game;
    cout << "                                                                                    W E L C O M E  TO  M O N O P O L Y" << endl;
    cout << "\n\n                                                                                          Would you like to play?" << endl;
    cout << "\n                                                                                           PRESS  [1]-Yes [0]-No " << endl;
    cin >> game;
    if (game == 0) {
        system("CLS");
        gotoxy(100, 10);
        cout << "You Exited the Game!" << endl;
        return 0;
    }
    else {
        system("CLS");
        cout << map;
    }

    COORD points[COUNT_COORD] = { 
        /*{6, 2},*/ { 21, 2 }, { 35, 2} , {48, 2}, {63, 2}, {76, 2}, {91, 2}, {105, 2}, {119, 2}, {132, 2}, {145, 2},
        {145, 7}, {145, 12}, {145, 17}, {145, 22}, {145, 27}, {145, 32}, {145, 37}, {145, 42}, {145, 47}, {145, 52},
        {132, 52}, {119, 52}, {105, 52}, {91, 52}, {76, 52}, {63, 52}, {48, 52}, { 35, 52}, { 21, 52}, {6, 52},
        {6, 47}, {6, 42}, {6, 37}, {6, 32}, {6, 27}, {6, 22}, {6, 17}, {6, 12}, {6, 7}
    };
    COORD pointsComputer[COUNT_COORD] = { 
        /*{6, 3},*/ { 21, 3 }, { 35, 3} , {48, 3}, {63, 3}, {76, 3}, {91, 3}, {105, 3}, {119, 3}, {132, 3}, {145, 3},
        {145, 8}, {145, 13}, {145, 18}, {145, 23}, {145, 28}, {145, 33}, {145, 38}, {145, 43}, {145, 48}, {145, 53},
        {132, 53}, {119, 53}, {105, 53}, {91, 53}, {76, 53}, {63, 53}, {48, 53}, { 35, 53}, { 21, 53}, {6, 53},
        {6, 48}, {6, 43}, {6, 38}, {6, 33}, {6, 28}, {6, 23}, {6, 18}, {6, 13}, {6, 8}
    };
    HANDLE h2 = GetStdHandle(STD_OUTPUT_HANDLE);
    COORD dicePoints[DICE] = { 
        {20, 24}, {20, 25}, {20, 26} , {20, 27} , {20, 28}, {125, 24}, {125, 25}, {125, 26} , {125, 27} , {125, 28}
    };
    HANDLE h3 = GetStdHandle(STD_OUTPUT_HANDLE);
    COORD propertyPoints[PROPERTY_POSITION] = { 
        {6, 2}, {21, 4}, {35, 2}, {48, 4}, {63, 4}, {76, 2}, {91, 4}, {105, 4}, {119, 2}, {132, 4},  {145, 2},
        {145, 9}, {145, 14}, {145, 17}, {145, 24}, {145, 27}, {145, 32}, {145, 39}, {145, 42}, {145, 49}, {145, 52},
        {132, 54}, {119, 52}, {105, 54}, {91, 52}, {76, 52}, {63, 54}, {48, 52}, { 35, 54}, { 21, 54}, {6, 52},
        {6, 49},  {6, 42}, {6, 39}, {6, 34},  {6, 27}, {6, 24},  {6, 17}, {6, 14}, {6, 9}
    };
    SetConsoleCursorPosition(h, { 6, 2 });
    SetConsoleTextAttribute(h2, 10);
    cout << "@";
    SetConsoleCursorPosition(h, { 6, 3 });
    SetConsoleTextAttribute(h2, 12);
    cout << "#";

    while (isRunning) {
            diceOne = throwADiceOne();
            switch (diceOne) {
            case 1:
                SetConsoleCursorPosition(h2, dicePoints[0]);
                SetConsoleTextAttribute(h2, 12);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[1]);
                cout << "#       #";
                SetConsoleCursorPosition(h2, dicePoints[2]);
                cout << "#   #   #";
                SetConsoleCursorPosition(h2, dicePoints[3]);
                cout << "#       #";
                SetConsoleCursorPosition(h2, dicePoints[4]);
                cout << "#########";
                Sleep(2000);
                break;
            case 2:
                SetConsoleCursorPosition(h2, dicePoints[0]);
                SetConsoleTextAttribute(h2, 14);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[1]);
                cout << "# #     #";
                SetConsoleCursorPosition(h2, dicePoints[2]);
                cout << "#       #";
                SetConsoleCursorPosition(h2, dicePoints[3]);
                cout << "#     # #";
                SetConsoleCursorPosition(h2, dicePoints[4]);
                cout << "#########";
                Sleep(2000);
                break;
            case 3:
                SetConsoleCursorPosition(h2, dicePoints[0]);
                SetConsoleTextAttribute(h2, 15);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[1]);
                cout << "# #     #";
                SetConsoleCursorPosition(h2, dicePoints[2]);
                cout << "#   #   #";
                SetConsoleCursorPosition(h2, dicePoints[3]);
                cout << "#     # #";
                SetConsoleCursorPosition(h2, dicePoints[4]);
                cout << "#########";
                Sleep(2000);
                break;
            case 4:
                SetConsoleCursorPosition(h2, dicePoints[0]);
                SetConsoleTextAttribute(h2, 9);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[1]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[2]);
                cout << "#       #";
                SetConsoleCursorPosition(h2, dicePoints[3]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[4]);
                cout << "#########";
                Sleep(2000);
                break;
            case 5:
                SetConsoleCursorPosition(h2, dicePoints[0]);
                SetConsoleTextAttribute(h2, 11);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[1]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[2]);
                cout << "#   #   #";
                SetConsoleCursorPosition(h2, dicePoints[3]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[4]);
                cout << "#########";
                Sleep(2000);
                break;
            case 6:
                SetConsoleCursorPosition(h2, dicePoints[0]);
                SetConsoleTextAttribute(h2, 13);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[1]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[2]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[3]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[4]);
                cout << "#########";
                Sleep(2000);
                break;
            }
            diceTwo = throwADiceTwo();
            switch (diceTwo) {
            case 1:
                SetConsoleCursorPosition(h2, dicePoints[5]);
                SetConsoleTextAttribute(h2, 12);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[6]);
                cout << "#       #";
                SetConsoleCursorPosition(h2, dicePoints[7]);
                cout << "#   #   #";
                SetConsoleCursorPosition(h2, dicePoints[8]);
                cout << "#       #";
                SetConsoleCursorPosition(h2, dicePoints[9]);
                cout << "#########";
                Sleep(2000);
                break;
            case 2:
                SetConsoleCursorPosition(h2, dicePoints[5]);
                SetConsoleTextAttribute(h2, 14);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[6]);
                cout << "# #     #";
                SetConsoleCursorPosition(h2, dicePoints[7]);
                cout << "#       #";
                SetConsoleCursorPosition(h2, dicePoints[8]);
                cout << "#     # #";
                SetConsoleCursorPosition(h2, dicePoints[9]);
                cout << "#########";
                Sleep(2000);
                break;
            case 3:
                SetConsoleCursorPosition(h2, dicePoints[5]);
                SetConsoleTextAttribute(h2, 15);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[6]);
                cout << "# #     #";
                SetConsoleCursorPosition(h2, dicePoints[7]);
                cout << "#   #   #";
                SetConsoleCursorPosition(h2, dicePoints[8]);
                cout << "#     # #";
                SetConsoleCursorPosition(h2, dicePoints[9]);
                cout << "#########";
                Sleep(2000);
                break;
            case 4:
                SetConsoleCursorPosition(h2, dicePoints[5]);
                SetConsoleTextAttribute(h2, 9);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[6]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[7]);
                cout << "#       #";
                SetConsoleCursorPosition(h2, dicePoints[8]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[9]);
                cout << "#########";
                Sleep(2000);
                break;
            case 5:
                SetConsoleCursorPosition(h2, dicePoints[5]);
                SetConsoleTextAttribute(h2, 11);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[6]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[7]);
                cout << "#   #   #";
                SetConsoleCursorPosition(h2, dicePoints[8]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[9]);
                cout << "#########";
                Sleep(2000);
                break;
            case 6:
                SetConsoleCursorPosition(h2, dicePoints[5]);
                SetConsoleTextAttribute(h2, 13);
                cout << "#########";
                SetConsoleCursorPosition(h2, dicePoints[6]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[7]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[8]);
                cout << "# #   # #";
                SetConsoleCursorPosition(h2, dicePoints[9]);
                cout << "#########";
                Sleep(2000);
                break;
            }

            if (turn == 2) {
                SetConsoleCursorPosition(h, { 6, 2 });
                SetConsoleTextAttribute(h2, 10);
                cout << " ";
                SetConsoleCursorPosition(h, points[diceTotal - 1]);
                SetConsoleTextAttribute(h, 10);
                cout << " ";
            }
            else if (turn == 1) {
                SetConsoleCursorPosition(h, { 6, 3 });
                SetConsoleTextAttribute(h2, 12);
                cout << " ";
                SetConsoleCursorPosition(h, pointsComputer[diceTotalComp - 1]);
                SetConsoleTextAttribute(h, 12);
                cout << " ";
            }
            if (move) {
                if (turn == 2) {
                    diceTotal += diceOne + diceTwo;
                    for (int i = accumulator; i < diceTotal; i++) {
                        if (i == 40) {
                            diceTotal = diceTotal - i;
                            accumulator = 0;
                            i = 0;
                        }
                        SetConsoleCursorPosition(h, points[i]);
                        SetConsoleTextAttribute(h, 10);
                        cout << "@";
                        Sleep(500);
                        SetConsoleCursorPosition(h, points[i]);
                        cout << " ";
                    }

                    SetConsoleCursorPosition(h, points[diceTotal - 1]);
                    SetConsoleTextAttribute(h, 10);
                    cout << "@";
                    accumulator = diceTotal;
                    move = false;

                    if (accumulator == 1 ||
                        accumulator == 3 ||
                        accumulator == 4 ||
                        accumulator == 6 ||
                        accumulator == 7 ||
                        accumulator == 9 ||
                        accumulator == 11 || 
                        accumulator == 12 || 
                        accumulator == 14 || 
                        accumulator == 17 || 
                        accumulator == 19 || 
                        accumulator == 21 || 
                        accumulator == 23 || 
                        accumulator == 26 || 
                        accumulator == 28 || 
                        accumulator == 29 || 
                        accumulator == 31 || 
                        accumulator == 33 || 
                        accumulator == 34 || 
                        accumulator == 36 || 
                        accumulator == 38 || 
                        accumulator == 39) {

                        gotoxy(170, 8);
                        cout << "Would you like to buy This Property?\n";
                        gotoxy(170, 9);
                        cin >> propertyBuy;
                        if (propertyBuy) {
                            propertyPlayer++;
                            moneyPlayer -= 200;
                            gotoxy(170, 11); 
                            cout << " Properties own by a player: " << propertyPlayer;
                            SetConsoleCursorPosition(h3, propertyPoints[accumulator]);
                            cout << "+";
                            gotoxy(170, 8);
                            cout << "                                                            ";
                        }
                    }
                } else if (turn == 1) {
                    diceTotalComp += diceOne + diceTwo;
                    for (int i = accumulatorComp; i < diceTotalComp; i++) {
                        if (i == 40) {
                            diceTotalComp = diceTotalComp - i;
                            accumulatorComp = 0;
                            i = 0;
                        }
                        SetConsoleCursorPosition(h, pointsComputer[i]);
                        SetConsoleTextAttribute(h, 12);
                        cout << "#";
                        Sleep(500);
                        SetConsoleCursorPosition(h, pointsComputer[i]);
                        cout << " ";
                    }
                    SetConsoleCursorPosition(h, pointsComputer[diceTotalComp - 1]);
                    SetConsoleTextAttribute(h, 12);
                    cout << "#";
                    accumulatorComp = diceTotalComp;
                    move = false;

                    if (accumulatorComp == 1 ||
                        accumulatorComp == 3 ||
                        accumulatorComp == 4 ||
                        accumulatorComp == 6 ||
                        accumulatorComp == 7 ||
                        accumulatorComp == 9 ||
                        accumulatorComp == 11 ||
                        accumulatorComp == 12 ||
                        accumulatorComp == 14 ||
                        accumulatorComp == 17 ||
                        accumulatorComp == 19 ||
                        accumulatorComp == 21 ||
                        accumulatorComp == 23 ||
                        accumulatorComp == 26 ||
                        accumulatorComp == 28 ||
                        accumulatorComp == 29 ||
                        accumulatorComp == 31 ||
                        accumulatorComp == 33 ||
                        accumulatorComp == 34 ||
                        accumulatorComp == 36 ||
                        accumulatorComp == 38 ||
                        accumulatorComp == 39) {

                        gotoxy(170, 8);
                        cout << "Would you like to buy This Property?\n";
                        gotoxy(170, 9);
                        cin >> propertyBuy;
                        if (propertyBuy) {
                            propertyComputer++;
                            moneyComputer -= 200;
                            gotoxy(170, 11);
                            cout << " Properties own by a player: " << propertyComputer;
                            SetConsoleCursorPosition(h3, propertyPoints[accumulatorComp]);
                            cout << "+";
                            gotoxy(170, 8);
                            cout << "                                                            ";
                        }
                    }
                }
            }
            if (!move) {
                if (turn == 1) {
                    gotoxy(170, 2);
                    cout << "Would you like to throw dice?\n";
                    gotoxy(170, 3);
                    cout << "PRESS [1]-Yes [0]-No";
                    gotoxy(170, 4);
                    cin >> takeATurn;
                    turn = 2;
                    if (takeATurn == 1) {
                        move = true;
                    }
                }
                else if (turn == 2) {
                    turn = 1;
                    move = true;
                }
            }
    }
}


