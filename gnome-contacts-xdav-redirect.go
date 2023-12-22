package main

import (
	"fmt"
	"log"
	"net/http"
	"os"
	"strings"

)

func main() {
	port := ":8088"
	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		if len(r.Method) == 0 || r.Method == "GET" {
			if strings.HasPrefix(r.URL.Path, "/remote.php/webdav") {
				w.WriteHeader(200)
			}
		} else if r.Method == "PROPFIND" {
			if strings.HasPrefix(r.URL.Path, "/.well-known/caldav/") || strings.HasPrefix(r.URL.Path, "/remote.php/caldav/") {
				fmt.Println("Redirect caldav")
				http.Redirect(w, r, "https://posteo.de:8843/calendars/YOUR_MAILBOX_NAME_HERE/default", http.StatusFound)
			} else if strings.HasPrefix(r.URL.Path, "/.well-known/carddav/") || strings.HasPrefix(r.URL.Path, "/remote.php/carddav/") {
				fmt.Println("Redirect carddav")
				http.Redirect(w, r, "https://posteo.de:8843/addressbooks/YOUR_MAILBOX_NAME_HERE/default", http.StatusFound)
			}
		}
	})
	log.Fatal(http.ListenAndServe(port, nil))
	os.Exit(0)
}
