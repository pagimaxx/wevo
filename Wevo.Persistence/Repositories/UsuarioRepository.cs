using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wevo.Domain.Entities.Domain;
using Wevo.Domain.Interfaces.Repositories;
using Wevo.Infrastructure.CrossCutting.Enums;
using Wevo.Infrastructure.CrossCutting.Utilities;
using Wevo.Persistence.Connection;

namespace Wevo.Persistence.Repositories
{
    public class UsuarioRepository : BaseConnection, IUsuarioRepository
    {
        private readonly IOptions<KeysConfig> _iChaveConfiguracao;
        private DataBaseType DataBaseType;

        public UsuarioRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            _iChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), _iChaveConfiguracao.Value.TypeDB, true);
        }

        public bool Atualizar(Usuario entity)
        {
            try
            {
                const string query =
                         @"UPDATE Usuarios
                             SET 
                                Nome = :Nome,
                                CPF = :CPF,
                                Email = :Email,
                                Telefone = :Telefone,
                                Sexo = :Sexo,
                                DataNascimento = :DataNascimento
                           WHERE Id = :Id";
                var parametros = new
                {
                    entity.Id,
                    entity.Nome,
                    entity.CPF,
                    entity.Email,
                    entity.Telefone,
                    entity.Sexo,
                    entity.DataNascimento,
                    entity.DataAlteracao
                };

                var resultado = IDbConn.CommandExecute(query, DataBaseType, parametros);

                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Cadastrar(Usuario entity)
        {
            try
            {
                const string query =
                        @"INSERT INTO Usuarios (Nome, CPF, Email, Telefone, Sexo, DataNascimento) 
                          VALUES (:Nome, :CPF, :Email, :Telefone, :Sexo, :DataNascimento)";

                var parametros = new
                {
                    entity.Nome,
                    entity.CPF,
                    entity.Email,
                    entity.Telefone,
                    entity.Sexo,
                    entity.DataNascimento
                };

                string sequenceName = null;

                if (DataBaseType == DataBaseType.Oracle)
                    sequenceName = SequenceHelper.GetSequenceName<Usuario>(entity);

                return Convert.ToInt32(IDbConn.CommandInsert(query, DataBaseType, parametros, sequenceName: sequenceName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario ObterPorId(int idUsuario)
        {
            try
            {
                const string query = @"SELECT * FROM Usuarios WHERE Id = :idUsuario ORDER BY Nome";
                return IDbConn.CommandQuery<Usuario>(query, DataBaseType, new { idUsuario }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usuario> ObterPorTexto(string nome)
        {
            try
            {
                const string query = @"SELECT * FROM Usuarios WHERE Nome LIKE :nome ORDER BY Nome";
                var parametro = new { nome = "%" + nome + "%" };
                return IDbConn.CommandQuery<Usuario>(query, DataBaseType, parametro).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            try
            {
                const string query = @"SELECT * FROM Usuarios ORDER BY Nome";
                return IDbConn.CommandQuery<Usuario>(query, DataBaseType).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remover(int idUsuario)
        {
            try
            {
                var query = @"DELETE FROM Usuarios
                           WHERE Id = :idUsuario";

                var resultado = IDbConn.CommandExecute(query, DataBaseType, new
                {
                    idUsuario
                });

                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
