KingKarel - Karel Remake
von Maximilian Schecklmann



Vorwort
Das Projekt KingKarel ist ein simples C# "Remake"
des Karel.c Projektes von Prof. Dr. Baumann.

Der Nutzen ist einzig und allein ein
von MinGW und CLion unabhöngiges Pro-
gramm zu schaffen, welches die Grund-
lagen der Programmierung mit den Auf-
gaben und den Räumen des Originals
erläutert.

Auslöser war die Übung für mich selbst
und die Frustration meiner Kommilitonen
und Kommilitoninnen, welche enorme Pro-
bleme mit der Installation und Vorbe-
reitung des originalen Projektes auf
Mac, Linux und im generellen hatten.

Das Projekt funktioniert prinzipiell
1 zu 1 wie das Original. Allerdings
gillt es zu beachten, dass C# zwar
ähnlich, allerdings nicht identisch
zu C ist und somit Punkte beachtet
werden müssen.

Alle Funktionen aus dem Original
wurden integriert und können hier
eingesehen werden:
https://fbim.oth-regensburg.de/~hem38149/files/karel/Karel_Reference_Card.pdf



Differenzen (C#/C)
Um die Skripte korrekt als C Dateien,
bzw. als Abgabe zu nutzen muss folgendes
beachtet werden.

1.	Genutzte Funktionen müssen im Skript
	bereits über der Funktion, welche diese
	aufruft deklariert werden.

2.	Foreach loops gibt es in C nicht.
	Weshalb sie ungültig sind und entfernt
	bzw. nicht genutzt werden dürfen.

3.	Levels.Load existiert im Original nicht.
	Ersetzt diese Zeile vor der Abgabe durch
	> "loadWorld(" nameOfWorld ");"
	Als nameOfWorld setzten Sie einfach
	den Inhalt der Funktion Levels.Load ein.
	> Levels.livingRoom	 ->  livingRoom			-> loadWorld("livingRoom");

4.	Wenn Sie die vorherigen Schritte abgeschlossen
	und beachtet haben, so können Sie den Inhalt
	der Klasse kopieren und in die AbgabeVorlage.c
	Datei einfügen und diese dann abgeben.



Tutorial
Für dieses Projekt wird das "Game.cs"-Skript
für Eingaben genutzt. Von dort aus wird das
Level geladen und Karel (Der Spieler) gesteuert.

Run startet außerdem mit dem Start der Anwendung

Nach erfolgreichem Durchlauf kann man durch
die Taste R das Level neustarten.

Unter /Samples finden Sie einige Beispiele,
welche Sie in ihr Game.cs Skript kopieren
und mit denen Sie herumprobieren können.



Bei Problemen, Fragen oder Interesse an gemeinsamen Projekt schreiben Sie mir unter
maximilian.schecklmann@st.oth-regensburg.de