<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8"/>

<!--
 * Copyright © 2018-2024
 * Merz Information and Communication Technology AG.
 * All rights reserved.
 * 
 * C021-DE
 * Einführung in CSS
-->

    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>University, Science and Literature Information Guide (USLIG)</title>
    <base href="http://localhost/uslig/"/>
    <link rel="stylesheet" type="text/css" href="styles/main.css"/>
  </head>
  <body>
    <header>
      <h1>University, Science and Literature Information Guide (USLIG)</h1>
      <menu>
      <div class="dropdown">
          <button class="dropdown-label">Universitäten</button>
          <div class="dropdown-points">
            <a href="universities/list-of-universities-by-name.html">Liste nach Namen</a>
            <a href="universities/list-of-universities-by-country.html">Liste nach Land</a>
          </div>
        </div>
        <div class="dropdown">
          <button class="dropdown-label">Wissenschaftler</button>
          <div class="dropdown-points">
            <a href="scientists/table-of-scientists.html">Tabelle</a>
            <a href="awards/list-of-nobel-prizes.html">Liste der Nobelpreise</a>
          </div>
        </div>
        <div class="dropdown">
          <button class="dropdown-label">Schriftsteller</button>
          <div class="dropdown-points">
            <a href="writers/table-of-writers.html">Tabelle</a>
            <a href="awards/list-of-nobel-prizes.html">Liste der Nobelpreise</a>
          </div>
        </div>
        <div class="dropdown">
          <button class="dropdown-label">Nobelpreise</button>
          <div class="dropdown-points">
            <a href="awards/list-of-nobel-prizes.html">Liste</a>
            <a href="awards/form-for-nobel-prize-laureates.html">Suche nach Nobelpreisträgern</a>
          </div>
        </div>
      </menu>
    </header>
    <main>
      <header>
        <h2>Suche nach Nobelpreisträgern</h2>
      </header>
<?php
    $nobel_prize_fields = [
      "physics" => "Physik",
      "chemistry" => "Chemie",
      "physiology-medicine" => "Physiologie oder Medizin",
      "literature" => "Literatur",
      "peace" => "Frieden",
      "economics" => "Wirtschaftswissenschaften"
    ];
    $nobel_prizes = [
        "1903" => [
            "physics" => ["Henri Becquerel", "Pierre Curie", "Marie Curie"]
        ],
        "1911" => [
            "chemistry" => ["Marie Curie"]
        ],
        "1938" => [
            "physics" => ["Enrico Fermi"]
        ],
        "1946" => [
            "literature" => ["Hermann Karl Hesse"]
        ],
        "1954" => [
            "physics" => ["Max Born", "Walther Bothe"],
            "literature" => ["Ernest Miller Hemingway"]
        ],
        "1957" => [
            "literature" => ["Albert Camus"]
        ],
        "2013" => [
            "physics" =>  ["François Englert", "Peter Ware Higgs"]
        ],
        "2016" => [
            "physics" => ["David James Thouless", "Duncan Haldane",
                    "John Michael Kosterlitz"]
        ]
    ];
    $year = $_GET["year"];
    $field = $_GET["field"];
    $nobel_prize_laureates = $nobel_prizes[$year][$field] ?? [];
    echo "<section class='year'>";
    echo "<h3>$year</h3>";
    echo "<div class='tiles fifth'>";
    echo "<section>";
    echo "<h4>$nobel_prize_fields[$field]</h4>";
    if (!$nobel_prize_laureates) {
        echo "<p>Keine Informationen gefunden.</p>";
    } else {
        echo "<ul>";
        foreach ($nobel_prize_laureates as $nobel_prize_laureate) {
            echo "<li>$nobel_prize_laureate</li>";
        }
        echo "</ul>";
    }
    echo "</section>";
    echo "</div>";
    echo "</section>";
    echo "<p>";
    echo "<button type='button' onclick='location.href=\"awards/form-for-nobel-prize-laureates.html\"'>Formular anzeigen</button>";
    echo "</p>";
?>
    </main>
    <footer>
      <p>Copyright&nbsp;©&nbsp;2018&#x2011;2024&nbsp;&nbsp;USIS.</p>
    </footer>
  </body>
</html>
