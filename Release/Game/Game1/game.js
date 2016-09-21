(function () {
    var Game = {
        roles: [
            { name: "PG", skill: [20, -20, 0, 20, 0, 10, 20, -20] },
            { name: "SG", skill: [10, -15, 5, 15, 5, 15, 15, -15] },
            { name: "SF", skill: [0, 0, 10, 10, 10, 10, 20, 0] },
            { name: "PF", skill: [-10, 10, 5, -10, 15, 10, -15, 15] },
            { name: "C", skill: [-20, 20, 0, -20, 20, 0, -20, 20] },
        ],
        skills: [{ name: "过人" }, { name: "篮板" }, { name: "干扰" }, { name: "抢断" }, { name: "盖帽" }, { name: "二分" }, { name: "三分" }, { name: "扣篮"}],
        cards: [10, 10, 15, 10, 15, 15, 15, 10],
        PlayerA: { role: {}, score: 0 },
        PlayerB: { role: {}, score: 0 },
        currplayer: "",
        timer: 0,
        init: function () {
            $("#divStart").show(); $("#divMain").hide(); $("#divStart").html("选择角色：");
            $.map(this.roles, function (n, i) {
                $("<input type=\"button\" style=\"margin:3px 5px;\" value=\"" + n.name + "\" />").bind("click", {}, function () {
                    Game.PlayerB.role = n;
                    Game.start();
                }).appendTo($("#divStart"));
            });
        },
        start: function () {
            $("#divStart").hide(); $("#divMain").show();
            this.setPanel("游戏开始...");
            this.timerStart();
            this.setPanel("开始发牌...");
            this.sendCard("A", -1); this.sendCard("A", this.getRandom(8)); this.sendCard("A", this.getRandom(8)); this.sendCard("A", this.getRandom(8)); this.sendCard("A", this.getRandom(8)); this.sendCard("A", this.getRandom(8));
            this.sendCard("B", -1); this.sendCard("B", this.getRandom(8)); this.sendCard("B", this.getRandom(8)); this.sendCard("B", this.getRandom(8)); this.sendCard("B", this.getRandom(8)); this.sendCard("B", this.getRandom(8));
            this.changePlayer();
        },
        getRandom: function (base) { return Math.floor(Math.random() * base); },
        addScore: function (player, score) { this["Player" + player].score = score; $("#score" + player).text(this["Player" + player].score); },
        setPanel: function (txt) { $("#scorepanel").text(txt + "\r\n" + $("#scorepanel").text()); },
        timerStart: function () { this.timer = setInterval(function () { $("#lblTime").text(parseInt($("#lblTime").text()) + 1); Game.isOver(); }, 1000); },
        timerStop: function () { clearInterval(this.timer); },
        sendCard: function (player, val) { $("<input type=\"button\" value=\"" + (val == -1 ? "过" : this.skills[val].name) + "\" intval=\"" + val + "\" />").bind("click", {}, function () { Game.pushCard(player, val, this); }).appendTo($("#card" + player)); },
        pushCard: function (player, val, btn) {
            if (this.currplayer != player) { this.setPanel("等待对方出牌..."); return; }
            this.setPanel("Player" + player + " " + $(btn).val()); if (val > -1) { btn.remove(); this.sendCard(player, this.getRandom(8)); }
            this.changePlayer();
        },
        changePlayer: function () {
            if (this.currplayer == "A") { this.currplayer = "B"; this.setPanel("PlayerB 出牌"); } else { this.currplayer = "A"; this.setPanel("PlayerA 出牌"); }
        },
        isSuccess: function (player, skill, card) { return this.getRandom(100) < 50 + this["Player" + player].role.skill[skill] + (card == -1 ? 0 : this.cards[card]); },
        isOver: function () { if (parseInt($("#lblTime").text()) >= 10) { this.setPanel("游戏结束！"); this.timerStop(); $("#divMain input").attr("disabled", "disabled"); if (this.PlayerA.score > this.PlayerB.score) { this.setPanel("PlayerA 胜利！"); } else if (this.PlayerA.score < this.PlayerB.score) { this.setPanel("PlayerB 胜利！"); } else { this.setPanel("平局！"); } } }
    };

    $(function () {
        Game.init();
    });
})();