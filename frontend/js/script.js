const baseURL = "http://localhost:5200/api/movie"

const movieFetch = async () => {
    //we need to await our fetch here and store it in a variable
    const res = await fetch(baseURL);
    const data = await res.json();
    console.log(data);
}
movieFetch();

const movie = {
    title: "2 Fast 2 Furious",
    director: "John Singelton",
    releaseYear: 2003,
    rating: 100
}

const createMovie = async (newMovie) =>{
    const res = await fetch(baseURL + "/addmovie", {
        method: "POST",
        headers:{"Content-Type": "application/json"},
        body: JSON.stringify(newMovie),

    })
    const data = await res.json();
    console.log(data);
}
createMovie(movie);