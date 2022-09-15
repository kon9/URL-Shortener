async function createUrl(longUrl) {
  const response = await fetch("api/url", {
    method: "POST",
    headers: { Accept: "application/json", "Content-Type": "application/json" },
    body: JSON.stringify({
      longUrl: longUrl,
      UrlCode: "null",
      ShortUrl: "null",
    }),
  });

  if (response.ok === true) {
    const url = await response.json();
    document.querySelector("tbody").append(row(url));
  } else {
    const error = await response.json();
    console.log(error.message);
  }
}

async function DeleteUrl(id) {
  const response = await fetch("/api/url/" + id, {
    method: "DELETE",
    headers: { Accept: "application/json" },
  });

  if (response.ok === true) {
    const url = await response.json();
    document.querySelector("tr[data-rowid='" + url.id + "']").remove();
  }
}

function row(url) {
  const tr = document.createElement("tr");
  tr.setAttribute("data-rowid", url.id);

  const idTd = document.createElement("td");
  idTd.append(url.id);
  tr.append(idTd);

  const longUrlTd = document.createElement("td");
  longUrlTd.innerHTML = `<a href="${url.longUrl}">${url.longUrl}</a>`;
  tr.append(longUrlTd);

  const shortUrlTd = document.createElement("td");
  shortUrlTd.innerHTML = `<a href="${url.shortUrl}">${url.shortUrl}</a>`;
  tr.append(shortUrlTd);

  const linksTd = document.createElement("td");

  const removeLink = document.createElement("a");
  removeLink.setAttribute("data-id", url.id);
  removeLink.setAttribute("style", "cursor:pointer;padding:15px;");
  removeLink.append("Delete");
  removeLink.addEventListener("click", (e) => {
    e.preventDefault();
    DeleteUrl(url.id);
  });

  linksTd.append(removeLink);
  tr.appendChild(linksTd);

  return tr;
}

document.getElementById("convertBtn").addEventListener("click", async () => {
  const longUrl = document.getElementById("longUrl").value;
  await createUrl(longUrl);
});
