# GuidaWeb
Web App scritta in ASP.NET per allestire e gestire in modo semplice ed economico un'audioguida museale fruibile dai visitatori direttamente sui loro cellulari.

# Stato di sviluppo
Quest'app è stata scritta per un progetto scolastico che aveva il fine di dotare un museo locale di una guida multimediale e ha raggiunto uno stato di beta: utilizzabile, stabile ma ancora carente di diverse caratteristiche (script di installazione, livelli di accesso, generazione automatica QR code, editor HTML) e con un interfaccia di amministrazione molto spartana, il rilascio di una versione 1.0 dell'app era pianificato a 3 mesi dalla presentazione della beta avvenuta a fine maggio 2017 ma purtroppo l'insegnante di allora è stato costretto ad annullare il progetto e non conoscendo altri potenziali utenti ho deciso di cessarne lo sviluppo. Lascio a disposizione il codice per chi vuole prendere spunto, proseguire autonomamente lo sviluppo o compilare il programma per usarlo così com'è.

# Come funziona?
L'applicazione organizza i dati in due tabelle: Schede e PagineH, la prima contiene le varie sezioni dell'audioguida, la seconda le eventuali pagine statiche HTML che si vogliono rendere visibili ai visitatori.

# Cos'è una scheda?
Una scheda rappresenta un particolare luogo/oggetto del museo per il quale si vuol fornire maggiori informazioni ai visiatori, può contenere una descrizione testuale, un immagine e una registrazione audio. Ogni scheda è contraddistinta da un ID numerico unico e ha il suo URL che potrà essere salvato in un QR Code o in un tag NFC da applicare in un luogo appropriato del museo per permettere ai visitatori una facile apertura della scheda informativa relativa a ciò che stanno osservando.

# Cos'è una pagina statica?
Oltre alle schede l'applciazione permette di creare pagine statiche, utili ad esempio quando si vogliono mostrare informazioni "generali" ai visitatori (ad esempio la storia del museo, gli orari o i prezzi). Le pagine statiche vanno scritte dall'utente in HTML, sono contraddistinte da un ID testuale unico e come le schede hanno un loro URL.

# Come si effettua il deployment?
Per effettuare il deployment è necessario Windows Server, IIS 8, ASP.NET 4.5.2 e Microsoft SQL Server Express. Per caricare l'applicazione sul server seguire questa guida https://docs.microsoft.com/en-us/visualstudio/deployment/deploy-iis-with-web-deploy?view=vs-2017 per predisporre un database creare un nuovo database su SQL server e inizializzarlo eseguendo il file "tabella.sql". In alternativa è possibiel distribuire l'applicazione su servizi cloud come Azure o uno shared hosting ASP.NET.

# Cosa fare dopo il deployment?
Dopo il deployment si consiglia di fare login nel backend con la password di default "default" per creare una home page (per farlo bisogna creare una pagina statica con titolo "Home"), modificare la password di default e sostituire il titolo predefinito.

# Maggiori informazioni
Per maggiori informazioni siete invitati a visionare l'apposito articolo sul mio sito web
http://www.emilianosandri.it/index.php/14-progetti/16-guidaweb
