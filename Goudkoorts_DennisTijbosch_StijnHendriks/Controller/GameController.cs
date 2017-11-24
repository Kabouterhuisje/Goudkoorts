using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

    class GameController
    {
        private bool _isGameStarted;
        private int _spawnIntervalCounter;

        private Game _game;
        private Input _inputView;
        private Output _outputView;

        public Timer _gameTimer;

        public GameController()
        {
            _spawnIntervalCounter = 0;
            _inputView = new Input();
            _outputView = new Output();
            _game = new Game();
            _isGameStarted = false;
            _gameTimer = new Timer();
            _gameTimer.Interval = 1000;
            _gameTimer.Start();
            _gameTimer.Elapsed += new ElapsedEventHandler(gameTimer_Elapsed);
        }

        public void Go()
        {
            bool change = false;
            bool cancelled = false;
            while (!_game.IsGameOver && !cancelled)
            {
                change = false;
                ConsoleKeyInfo input;
                if (!_isGameStarted)
                {
                    _outputView.ShowGameStart();
                    input = _inputView.GetInput();
                    _game.buildMap();
                    _outputView.Drawmap(_game.Track);
                    _isGameStarted = true;
                }
                else
                {
                    input = _inputView.GetInput();
                    if (input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1)
                    {
                        ChangeableTrack changeableTrack = (ChangeableTrack)_game.Track.trackList.First(v => v.X == 3 && v.Y == 5);
                        changeableTrack.Toggle();
                        change = true;
                    }
                    else if (input.Key == ConsoleKey.D2 || input.Key == ConsoleKey.NumPad2)
                    {
                        ChangeableTrack changeableTrack = (ChangeableTrack)_game.Track.trackList.First(v => v.X == 5 && v.Y == 5);
                    changeableTrack.Toggle();
                        change = true;
                    }
                    else if (input.Key == ConsoleKey.D3 || input.Key == ConsoleKey.NumPad3)
                    {
                        ChangeableTrack changeableTrack = (ChangeableTrack)_game.Track.trackList.First(v => v.X == 6 && v.Y == 7);
                    changeableTrack.Toggle();
                        change = true;
                    }
                    else if (input.Key == ConsoleKey.D4 || input.Key == ConsoleKey.NumPad4)
                    {
                        ChangeableTrack changeableTrack = (ChangeableTrack)_game.Track.trackList.First(v => v.X == 8 && v.Y == 7);
                    changeableTrack.Toggle();
                        change = true;
                    }
                    else if (input.Key == ConsoleKey.D5 || input.Key == ConsoleKey.NumPad5)
                    {
                        ChangeableTrack changeableTrack = (ChangeableTrack)_game.Track.trackList.First(v => v.X == 9 && v.Y == 5);
                    changeableTrack.Toggle();
                        change = true;
                    }
                    //Nexts moeten opnieuw worden gezet omdat de baan is gewijzigd (wissels)
                    if (change)
                    {
                        _game.Track.SetNexts();
                        _outputView.CleanConsole();
                        _outputView.TrackChanged();
                        _outputView.DrawScore(_game.Score);
                        _outputView.Drawmap(_game.Track);
                    }
                }
            }
        }

        private void gameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _gameTimer.Stop();
            if (_isGameStarted && !_game.IsGameOver)
            {
                int newScore = 0;
                List<TrackField> carList = _game.Track.trackList.FindAll(v => v.Car != null);
                foreach (TrackField tempTrackField in carList)
                {
                    _game.IsGameOver = !tempTrackField.Move(out newScore, _game.Score);
                    if (_game.IsGameOver) 
                    {
                        _outputView.GameOver();
                        _inputView.GetInput();
                        return;
                    }
                    if (newScore != _game.Score) 
                    {
                        if (_gameTimer.Interval > 200 && _gameTimer.Interval - newScore > 200)
                        {
                            _gameTimer.Interval = _gameTimer.Interval - newScore;
                        }
                        _game.Score = newScore;
                    }
                }

                //nieuwe karretje spawnen
                _spawnIntervalCounter++;
                if (_spawnIntervalCounter >= _game.CarSpawnInterval)
                {
                    Random r = new Random();
                    _spawnIntervalCounter = 0;
                    _game.CarSpawnInterval = r.Next(2, 20);
                    _game.Track.addCar();
                }

                if (newScore != _game.Score) 
                {
                    _gameTimer.Interval = _gameTimer.Interval > 100 ? _gameTimer.Interval - newScore : 200;
                    _game.Score = newScore;
                }

                //Score bijwerken wanneer een vol schip aankomt
                Ship ship = (Ship)_game.Track.trackList.FirstOrDefault(v => v.X == 9 && v.Y == 1);
                if (ship.IsFull())
                {
                    _game.Score += 10;
                    ship.Load = 0;
                }
                _outputView.CleanConsole();
                _outputView.ShipLoad(ship.Load, ship.MaxLoad);
                _outputView.DrawScore(_game.Score);
                _outputView.Drawmap(_game.Track);
            }
            _gameTimer.Start();
        }
    }

