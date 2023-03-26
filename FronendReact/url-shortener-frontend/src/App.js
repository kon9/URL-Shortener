import React, { useState } from "react";
import axios from "axios";
import "./App.css";

function App() {
  const [longUrl, setLongUrl] = useState("");
  const [shortUrl, setShortUrl] = useState(null);
  const [error, setError] = useState(null);

  const shortenUrl = async () => {
    try {
      const response = await axios.post(
        "https://localhost:7041/generate",
        { longUrl },
        { headers: { "Content-Type": "application/json" } }
      );

      setShortUrl(response.data.shortUrl);
      setError(null);
    } catch (err) {
      setError(err.response.data.title || "An error occurred.");
      setShortUrl(null);
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>URL Shortener</h1>
        <div>
          <input
            type="text"
            placeholder="Enter long URL"
            value={longUrl}
            onChange={(e) => setLongUrl(e.target.value)}
          />
          <button onClick={shortenUrl}>Shorten</button>
        </div>
        {shortUrl && (
          <div>
            <p>Shortened URL:</p>
            <a href={shortUrl} target="_blank" rel="noreferrer">
              {shortUrl}
            </a>
          </div>
        )}
        {error && <p className="error">{error}</p>}
      </header>
    </div>
  );
}

export default App;
