# MathematicalLinguisticsTask1

Wykorzystując deterministyczny automat skończony (DFA) napisz program będący symulatorem
parkometru. Parkometr działa w następujący sposób:
1. Do urządzenia można wrzucać monety o nominałach 1 zł, 2 zł i 5 zł.
2. Monety mogą być wrzucane tylko pojedynczo, nie można wrzucić dwóch lub więcej monet
na raz.
3. Koszt miejsca parkingowego wynosi 7 zł.
4. Parkomat nie wydaje reszty.
5. Jeżeli suma wrzuconych monet będzie wyższa niż 7 zł wtedy DFA przechodzi do stanu
nieakceptowalnego. Zakładamy zatem, że w takiej sytuacji automat zwraca wszystkie
dotychczas wrzucone monety i powraca do stanu oczekiwania.
