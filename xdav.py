""" xdav

Redirect CardDav and CalDav requests sent to a NextCloud server
to posteo.
"""
# pylint: disable=too-few-public-methods
# pylint: disable=locally-disabled
# pylint: disable=duplicate-code
# pylint: disable=bare-except
# pylint: disable=too-many-instance-attributes
from http.server import ThreadingHTTPServer, BaseHTTPRequestHandler


CALDAV = 'https://posteo.de:8843/calendars/bschau/default'
CARDDAV = 'https://posteo.de:8843/addressbooks/bschau/default'


class RedirectHandler(BaseHTTPRequestHandler):
    """ xdav Redirect Handler. """

    def do_GET(self):           # pylint: disable=C0103
        """ Handle GET request. """
        if self.path == '/remote.php/webdav/':
            self.send_response(200)
            self.end_headers()


    def do_PROPFIND(self):      # pylint: disable=C0103
        """ Handle PROPFIND request. """
        if self.is_caldav(self.path):
            self.send_redirect(CALDAV)
        elif self.is_carddav(self.path):
            self.send_redirect(CARDDAV)


    @staticmethod
    def is_caldav(path):
        """ Check to see if path points to a CalDav request.
            Arguments:
                path - path to check
        """
        return (path.startswith(".well-known/caldav") or
                path.startswith("/remote.php/caldav"))


    @staticmethod
    def is_carddav(path):
        """ Check to see if path points to a CardDav request.
            Arguments:
                path - path to check
        """
        return (path.startswith(".well-known/carddav") or
                path.startswith("/remote.php/carddav"))


    def send_redirect(self, location):
        """ Send 302 Location response.
            Arguments:
                location - redirect to URL.
        """
        self.send_response(302)
        self.send_header('Location', location)
        self.end_headers()


ThreadingHTTPServer(("localhost", 8088), RedirectHandler).serve_forever()
