import React, { useState } from "react";
import axios from "axios";
import QRCode from 'qrcode.react';
import { BrowserRouter as Router, Route, Routes, Link, Navigate } from "react-router-dom";
import "./App.css";
import Login from "./Login";
import Register from "./Register";

function App() {
  const [longUrl, setLongUrl] = useState("");
  const [shortUrl, setShortUrl] = useState(null);
  const [error, setError] = useState(null);
  const [loggedIn, setLoggedIn] = useState(false);
  const [token, setToken] = useState("");

  const shortenUrl = async () => {
    try {
      const response = await axios.post(
        "https://localhost:7041/generate",
        { longUrl },
        { headers: { "Content-Type": "application/json", "Authorization": `Bearer ${token}` } }
      );

      setShortUrl(response.data.shortUrl);
      setError(null);
    } catch (err) {
      setError(err.response.data.title || "An error occurred.");
      setShortUrl(null);
    }
  };

  const onLogin = (token) => {
    setLoggedIn(true);
    setToken(token);
  };

  return (
    <Router>
      <div className="App">
        <header className="App-header">
          <h1>URL Shortener</h1>
          <Routes>
            <Route path="/" element={
              loggedIn ? <Navigate to="/urlShortening" /> :
              <>
                <Link to="/register" className="btn">Register</Link>
                <Link to="/login" className="btn">Login</Link>
              </>
            } />
            <Route path="/login" element={<Login onLogin={onLogin} />} />
            <Route path="/register" element={<Register />} />
            <Route path="/urlShortening" element={
              <>
                <input
                  type="text"
                  placeholder="Enter long URL"
                  value={longUrl}
                  onChange={(e) => setLongUrl(e.target.value)}
                />
                <button onClick={shortenUrl}>Shorten</button>
                {shortUrl && (
                  <div>
                    <p>Shortened URL:</p>
                    <a href={shortUrl} target="_blank" rel="noreferrer">
                      {shortUrl}
                    </a>
                    <QRCode value={shortUrl} />
                  </div>
                )}
                {error && <p className="error">{error}</p>}
              </>
            } />
          </Routes>
        </header>
      </div>
    </Router>
  );
}

export default App;