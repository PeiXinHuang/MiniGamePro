from flask import Flask, request, jsonify
class NetManager:
    def __init__(self):
        self.app = Flask(__name__)
        self.ip = "0.0.0.0"
        self.port = 8000
        self.setup_routes()

    def run(self):
        self.app.run(host = self.ip, port = self.port)
    
    def setup_routes(self):
        self.app.add_url_rule('/rank', 'rank', self.rank, methods=['POST'])

    def rank(self):
        data = request.get_json()
        action = data.get('action')
        if action == "send_get_rank_data_c2s":
            userId = data.get('userId')
            response = {
                'userId': userId,
                'rankIndex': 50
            }
            return jsonify(response)
        else:
            pass



