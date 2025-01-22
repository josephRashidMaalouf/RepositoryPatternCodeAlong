﻿using Application.Interfaces;
using Application.Models;
using Infrastructure.MongoDb.Entities;
using MongoDB.Driver;

namespace Infrastructure.MongoDb.Repositories;

public class PeopleMongoRepository : IPeopleRepository
{
    private readonly IMongoCollection<Person> _collection;
    private const string CollectionName = "People";
    private const string DatabaseName = "PeopleDb";
    private const string ConnectionString = "mongodb://localhost:27017";

    public PeopleMongoRepository()
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        _collection = db.GetCollection<Person>(CollectionName);
    }

    public async Task<IEnumerable<ReadPersonModel>> GetAllAsync()
    {
        var filter = Builders<Person>.Filter.Empty;
        var people = await _collection.Find(filter).ToListAsync();
        return people.Select(p => p.ToReadModel());
    }

    public async Task<ReadPersonModel> AddAsync(AddPersonModel model)
    {
        var entity = model.ToEntity();
        await _collection.InsertOneAsync(entity);
        return entity.ToReadModel();
    }
}